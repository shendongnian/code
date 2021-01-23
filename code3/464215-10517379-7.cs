     public static class MicrosoftStreamExtensions
        {
            public static IRandomAccessStream AsRandomAccessStream(this Stream stream)
            {
                return new RandomStream(stream);
            }
        }
        class RandomStream : IRandomAccessStream
        {
            Stream internstream;
            public RandomStream(Stream underlyingstream)
            {
                internstream = underlyingstream;
            }
            public IInputStream GetInputStreamAt(ulong position)
            {
                internstream.Position = (long)position;
                return internstream.AsInputStream();
            }
            public IOutputStream GetOutputStreamAt(ulong position)
            {
                internstream.Position = (long)position;
                return internstream.AsOutputStream();
            }
            public ulong Size
            {
                get
                {
                    return (ulong)internstream.Length;
                }
                set
                {
                    internstream.SetLength((long)value);
                }
            }
            public bool CanRead
            {
                get { return internstream.CanRead; }
            }
            public bool CanWrite
            {
                get { return internstream.CanWrite; }
            }
            public IRandomAccessStream CloneStream()
            {
                //HACK, this is not clone, proper implementation is required, returned object will share same internal stream
                return new RandomStream(this.internstream);
            }
            public ulong Position
            {
                get { return (ulong)internstream.Position; }
            }
            public void Seek(ulong position)
            {
                internstream.Seek((long)position, SeekOrigin.Current);
            }
            public void Dispose()
            {
                internstream.Dispose();
            }
            public Windows.Foundation.IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
            {
                throw new NotImplementedException();
            }
            public Windows.Foundation.IAsyncOperation<bool> FlushAsync()
            {
                throw new NotImplementedException();
            }
            public Windows.Foundation.IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
            {
                throw new NotImplementedException();
            }
        }
