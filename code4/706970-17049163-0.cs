    using (System.IO.UnmanagedMemoryStream memoryStream = new UnmanagedMemoryStream(pointer, length, length, FileAccess.Read))
    {
        byte[] imageBytes = new byte[length];
        memoryStream.Read(imageBytes, 0, length);
    }
