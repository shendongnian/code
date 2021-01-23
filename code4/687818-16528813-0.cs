    // Note that due to the using statement, this will close the stream at the end
    // of the block
    using (var writer = new StreamWriter(stream))
    {
        writer.Write(text);
    }
