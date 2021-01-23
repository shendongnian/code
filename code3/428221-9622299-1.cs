    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace Chapter10Reader
    {
        public sealed class PacketScanner : IDisposable
        {
            // 128K buffer... tweak this.
            private const int BufferSize = 1024 * 128;
    
            /// <summary>
            /// Where in the file does the buffer start?
            /// </summary>
            private long bufferStart;
    
            /// <summary>
            /// Where in the file does the buffer end (exclusive)?
            /// </summary>
            private long bufferEnd;
    
            /// <summary>
            /// Where are we in the file, logically?
            /// </summary>
            private long logicalPosition;
    
            // Probably cached by FileStream, but we use it a lot, so let's
            // not risk it...
            private readonly long fileLength;
    
            private readonly FileStream stream;
            private readonly byte[] buffer = new byte[BufferSize];        
    
            private PacketScanner(FileStream stream)
            {
                this.stream = stream;
                this.fileLength = stream.Length;
            }
    
            public void MoveToEnd()
            {
                logicalPosition = fileLength;
                bufferStart = -1; // Invalidate buffer
                bufferEnd = -1;
            }
    
            public void MoveToBeforeStart()
            {
                logicalPosition = -1;
                bufferStart = -1;
                bufferEnd = -1;
            }
    
            private byte this[long position]
            {
                get 
                {
                    if (position < bufferStart || position >= bufferEnd)
                    {
                        FillBuffer(position);
                    }
                    return buffer[position - bufferStart];
                }
            }
    
            /// <summary>
            /// Fill the buffer to include the given position.
            /// If the position is earlier than the buffer, assume we're reading backwards
            /// and make position one before the end of the buffer.
            /// If the position is later than the buffer, assume we're reading forwards
            /// and make position the start of the buffer.
            /// If the buffer is invalid, make position the start of the buffer.
            /// </summary>
            private void FillBuffer(long position)
            {
                long newStart;
                if (position > bufferStart)
                {
                    newStart = position;
                }
                else
                {
                    // Keep position *and position + 1* to avoid swapping back and forth too much
                    newStart = Math.Max(0, position - buffer.Length + 2);
                }
                // Make position the start of the buffer.
                int bytesRead;
                int index = 0;
                stream.Position = newStart;
                while ((bytesRead = stream.Read(buffer, index, buffer.Length - index)) > 0)
                {
                    index += bytesRead;
                }
                bufferStart = newStart;
                bufferEnd = bufferStart + index;
            }
    
            /// <summary>
            /// Make sure the buffer contains the given positions.
            /// 
            /// </summary>
            private void FillBuffer(long start, long end)
            {
                if (end - start > buffer.Length)
                {
                    throw new ArgumentException("Buffer not big enough!");
                }
                if (end > fileLength)
                {
                    throw new ArgumentException("Beyond end of file");
                }
                // Nothing to do.
                if (start >= bufferStart && end < bufferEnd)
                {
                    return;
                }
                // TODO: Optimize this more to use whatever bits we've actually got.
                // (We're optimized for "we've got the start, get the end" but not the other way round.)
                if (start >= bufferStart)
                {
                    // We've got the start, but not the end. Just shift things enough and read the end...
                    int shiftAmount = (int) (end - bufferEnd);
                    Buffer.BlockCopy(buffer, shiftAmount, buffer, 0, (int) (bufferEnd - bufferStart - shiftAmount));
                    stream.Position = bufferEnd;
                    int bytesRead;
                    int index = (int)(bufferEnd - bufferStart - shiftAmount);
                    while ((bytesRead = stream.Read(buffer, index, buffer.Length - index)) > 0)
                    {
                        index += bytesRead;
                    }
                    bufferStart += shiftAmount;
                    bufferEnd = bufferStart + index;
                    return;
                }
    
                // Just fill the buffer starting from start...
                bufferStart = -1;
                bufferEnd = -1;
                FillBuffer(start);
            }
    
            /// <summary>
            /// Returns the header of the next packet, or null 
            /// if we've reached the end of the file.
            /// </summary>
            public PacketHeader NextHeader()
            {
                for (long tryPosition = logicalPosition + 1; tryPosition < fileLength - 23; tryPosition++)
                {
                    if (this[tryPosition] == 0x25 && this[tryPosition + 1] == 0xEB)
                    {
                        FillBuffer(tryPosition, tryPosition + 24);
                        int bufferPosition = (int) (tryPosition - bufferStart);
                        if (PacketHeader.CheckPacketHeaderChecksum(buffer, bufferPosition))
                        {
                            logicalPosition = tryPosition;
                            return PacketHeader.Parse(buffer, bufferPosition, tryPosition);
                        }
                    }
                }
                logicalPosition = fileLength;
                return null;
            }
    
            /// <summary>
            /// Returns the header of the previous packet, or null 
            /// if we've reached the start of the file.
            /// </summary>
            public PacketHeader PreviousHeader()
            {
                for (long tryPosition = logicalPosition - 1; tryPosition >= 0; tryPosition--)
                {
                    if (this[tryPosition + 1] == 0xEB && this[tryPosition] == 0x25)
                    {
                        FillBuffer(tryPosition, tryPosition + 24);
                        int bufferPosition = (int)(tryPosition - bufferStart);
                        if (PacketHeader.CheckPacketHeaderChecksum(buffer, bufferPosition))
                        {
                            logicalPosition = tryPosition;
                            return PacketHeader.Parse(buffer, bufferPosition, tryPosition);
                        }
                    }
                }
                logicalPosition = -1;
                return null;
            }
    
            public static PacketScanner OpenFile(string filename)
            {
                return new PacketScanner(File.OpenRead(filename));
            }
    
            public void Dispose()
            {
                stream.Dispose();
            }
        }
    }
