    using (WordprocessingDocument myDocument = WordprocessingDocument.Open(@"C:\users\" + Environment.UserName + @"\Desktop\eastAsiaFix.dotm", true))
    {
      StyleDefinitionsPart stylesPart = myDocument.MainDocumentPart.StyleDefinitionsPart;
      if (stylesPart == null)
      {
        Console.Out.WriteLine("No styles part found.");
        return;
      }
      foreach(var style in stylesPart.Styles.Descendants<Style>())
      {          
        foreach(var rf in style.Descendants<RunFonts>())
        {
          if(rf.EastAsia != null)
          {
            Console.Out.WriteLine("Found: {0}", rf.EastAsia.Value);
            rf.EastAsia.Value = "MS Mincho";
          } 
        }               
      }      
    }
