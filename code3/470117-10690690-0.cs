    public static void ReadFootnoteNumberingRestartSettings()
    {
      using (WordprocessingDocument wordDoc = 
             WordprocessingDocument.Open(@"c:\temp\Doc1.docx", true)) 
      {
        FootnoteDocumentWideProperties fdwp = 
                 wordDoc.MainDocumentPart.DocumentSettingsPart.Settings.Elements<FootnoteDocumentWideProperties>().FirstOrDefault();
        if (fdwp == null)
        {
          Console.Out.WriteLine("No document wide footnote settings specified.");
          return;
        }
        if (fdwp.NumberingRestart == null)
        {
          Console.Out.WriteLine("No numbering restart settings specified.");
          return;
        }
        Console.Out.WriteLine("Numbering restart option: {0}", fdwp.NumberingRestart.Val);    
      }
    }
    static void Main(string[] args)
    {
      ReadFootnoteNumberingRestartSettings();
    }
