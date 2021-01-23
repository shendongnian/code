                hostChannel = channelFactory.CreateChannel();
                ((IContextChannel)hostChannel).OperationTimeout = new TimeSpan(3, 0, 0);
                bool moreChunks = true;
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileWritePath)))
                {
                    writer.BaseStream.SetLength(0);
                    while (moreChunks)
                    {
                        FileMessage message = hostChannel.ReceiveFile();
                        moreChunks = message.FileMetaData.MoreChunks;
                        UpdateTotalBytesTransferred(message);
                        writer.BaseStream.Position = filePosition;
                        message.ChunkData.CopyTo(writer.BaseStream);
                        TotalBytesTransferred = message.FileMetaData.FilePosition;
                        filePosition += message.FileMetaData.ChunkLength;
                    }
                    OnTransferComplete(this, EventArgs.Empty);
                }
