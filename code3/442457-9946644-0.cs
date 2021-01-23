    public static bool PrintImage(string filePath) {
      PrintDocument pd = new PrintDocument();
      pd.PrintPage += delegate (sender, e) { printPage(filePath, e); };
      pd.Print();
      return true;
    }
    
    private static void printPage(string filePath, PrintPageEventArgs e) {
      ...
    }
