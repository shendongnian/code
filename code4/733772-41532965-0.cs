    static void SendStreamToString(Action<StreamWriter> action, out string destination)
    {
        using (var stream = new MemoryStream())
        using (var writer = new StreamWriter(stream, Encoding.Unicode))
        {
            action(writer);
            writer.Flush();
            stream.Position = 0;
            destination = Encoding.Unicode.GetString(stream.GetBuffer(), 0, (int)stream.Length);
        }
    }
