    public static class RichtTextExtensions
    {
        public static ExcelRichText Add(this ExcelRichTextCollection richTextCollection,
            string text, bool bold = false, bool italic = false, Color? color = null, float size = 11,
            bool underline = false, string fontName = "Segoe UI Light")
        {
            var richText = richTextCollection.Add(text);
    
            richText.Color = color ?? Color.Black;
            richText.Bold = bold;
            richText.Italic = italic;
            richText.Size = size;
            richText.FontName = fontName;
            richText.UnderLine = underline;
    
            return richText;
        }
    }
