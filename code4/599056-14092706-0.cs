    String s = "hello";
    Byte[] bytes = Encoding.UTF8.GetBytes(s);
    using (Stream f = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync
        ("hello.txt", CreationCollisionOption.OpenIfExists))
    {
        f.Seek(0, SeekOrigin.End);
        await f.WriteAsync(bytes, 0, bytes.Length);
    }
