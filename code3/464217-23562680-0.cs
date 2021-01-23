            InMemoryRandomAccessStream raStream =
                new InMemoryRandomAccessStream();
            DataWriter writer = new DataWriter(raStream);
            // Write the bytes to the stream
            writer.WriteBytes(data);
            // Store the bytes to the MemoryStream
            await writer.StoreAsync();
            await writer.FlushAsync();
            // Detach from the Memory stream so we don't close it
            writer.DetachStream();
            raStream.Seek(0);
            BitmapImage bitMapImage = new BitmapImage();
            bitMapImage.SetSource(raStream);
            image.Source = bitMapImage;
        }
