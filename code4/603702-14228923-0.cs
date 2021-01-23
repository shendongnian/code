    public string GetRandHtmlColor(){
    
        System.Drawing.Color c = GetRandColor();
        return System.Drawing.ColorTranslator.ToHtml(c);
    }
