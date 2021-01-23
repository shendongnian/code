    public SizeF GetSize(string text, Font font) {
    
        if (string.IsNullOrWhiteSpace(text) || font == null) {
            return default(SizeF);
        }
    
        return Graphics.MeasureString(text, font);
    }
