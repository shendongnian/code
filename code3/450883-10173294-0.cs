    Tidy tidy = new Tidy();
    tidy.Options.FixComments = true;
    tidy.Options.XmlTags = true;
    tidy.Options.XmlOut = true;
    string invalid = "<root>< <!--comment--->></root>";
    MemoryStream input = new MemoryStream(Encoding.ASCII.GetBytes(invalid));
    MemoryStream output = new MemoryStream();
    tidy.Parse(input, output, new TidyMessageCollection());
    string repaired = Encoding.UTF8.GetString(output.ToArray());
