    using (Stream s = File.OpenRead(@"C:\Users\JFM\Documents\latex3.xshd")) 
    {
    using (XmlTextReader reader = new XmlTextReader(s)) 
     {
       editor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load
           (reader, ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);    
     }
    }
