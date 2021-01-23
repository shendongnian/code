    public string WrapText(SpriteFont spriteFont, string text, float maxLineWidth)
    {
        string[] words = text.Split(' ');
        StringBuilder sb = new StringBuilder();
        float lineWidth = 0f;
        float spaceWidth = spriteFont.MeasureString(" ").X;
        foreach (string word in words)
        {
            Vector2 size = spriteFont.MeasureString(word);
            if (lineWidth + size.X < maxLineWidth)
            {
                sb.Append(word + " ");
                lineWidth += size.X + spaceWidth;
            }
            else
            {
                sb.Append("\n" + word + " ");
                lineWidth = size.X + spaceWidth;
            }
        }
        return sb.ToString();
    }
