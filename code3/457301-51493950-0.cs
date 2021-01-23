    private class UnicodeFontFactory : FontFactoryImp
    {
        private BaseFont _baseFont;
        public  UnicodeFontFactory()
        {
            string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arialuni.ttf");
            _baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);                
        }
        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
        {                                
            return new Font(_baseFont, size, style, color);
        }
    }  
  
