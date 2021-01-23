    string obj = "abcn\n\rüö&/<>";
    Console.WriteLine(Serialize(obj, StringEscapeHandling.Default));
    Console.WriteLine(Serialize(obj, StringEscapeHandling.EscapeHtml));
    Console.WriteLine(Serialize(obj, StringEscapeHandling.EscapeNonAscii));
---
    public static string Serialize(object o,StringEscapeHandling stringEscapeHandling)
    {
        StringWriter wr = new StringWriter();
        var jsonWriter = new JsonTextWriter(wr);
        jsonWriter.StringEscapeHandling = stringEscapeHandling;
        new JsonSerializer().Serialize(jsonWriter,o);
        return wr.ToString();
    }
