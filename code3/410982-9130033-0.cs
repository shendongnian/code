                if (myReader.Read())
                {
                    currentDocument.Size = myReader.GetBytes(0, 0, null, 0, 0);
                    // Reset the starting byte for the new BLOB.
                    long startIndex = 0;
                    int bufferSize = 8196;                   // Size of the BLOB buffer.
                    byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
                    long bytesInBuffer = 0;                            // The bytes returned from GetBytes.
                    // Continue reading and writing while there are bytes beyond the size of the buffer.
                    while (startIndex < currentDocument.Size)
                    {
                        bytesInBuffer = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize);
                        Array.Copy(outbyte, 0, currentDocument.Data, startIndex, bytesInBuffer);
                        startIndex += bytesInBuffer;
                    }
                }
