        public FileMessage ReceiveFile()
        {
            byte[] buffer = chunkedFile.NextChunk();
            FileMessage message = new FileMessage();
            message.FileMetaData = new FileMetaData(chunkedFile.MoreChunks, buffer.LongLength, chunkedFile.CurrentPosition);
            message.ChunkData = new MemoryStream(buffer);
            TotalBytesTransferred = chunkedFile.CurrentPosition;
            UpdateTotalBytesTransferred(message);
            if (!chunkedFile.MoreChunks)
            {
                OnTransferComplete(this, EventArgs.Empty);
                Timer timer = new Timer(20000f);
                timer.Elapsed += (sender, e) =>
                {
                    StopSession();
                    timer.Stop();
                };
                timer.Start();
            }
            return message;
        }
