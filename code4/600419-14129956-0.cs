    // This will use Encoding.UTF8 by default.
    using (var writer = File.CreateText("test.txt"))
    {
        for (int i = 0; i < docs.Paragraphs.Count; i++)
        {
            writer.WriteLine(docs.Paragraphs[i + 1].Range.Text.ToString());
        }
    }
