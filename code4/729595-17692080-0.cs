        IRandomAccessStreamWithContentType stream = await file.OpenReadAsync();
        byte[] byteArray = new byte[stream.Size];
        IBuffer byteBuffer = byteArray.AsBuffer();
        IBuffer x = await stream.ReadAsync(byteBuffer, (uint)byteArray.Length, 0);
        byte[] newArray = x.ToArray();
        String result = System.Text.Encoding.UTF8.GetString(newArray, 0, newArray.Length);
