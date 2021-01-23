    private void UpdateTotalBytesTransferred(FileMessage message)
        {
            long previousStreamPosition = 0;
            long totalBytesTransferredShouldBe = TotalBytesTransferred + message.FileMetaData.ChunkLength;
            Timer timer = new Timer(500f);
            timer.Elapsed += (sender, e) =>
            {
                if (TotalBytesTransferred + (message.ChunkData.Position - previousStreamPosition) < totalBytesTransferredShouldBe)
                {
                    TotalBytesTransferred += message.ChunkData.Position - previousStreamPosition;
                    previousStreamPosition = message.ChunkData.Position;
                }
                else
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();
        }
