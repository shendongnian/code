    using System;
    using TidyManaged;
    
    public class Test
    {
      public static void Main(string[] args)
      {
        using (Document doc = Document.FromString("<hTml><title>test</tootle><body>asd</body>"))
        {
          doc.ShowWarnings = false;
          doc.Quiet = true;
          doc.OutputXhtml = true;
          doc.CleanAndRepair();
          string parsed = doc.Save();
          Console.WriteLine(parsed);
        }
      }
    }
