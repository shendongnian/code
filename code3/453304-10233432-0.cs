    public void PrintA4Factuur()
    {
      artikelPosition = 0
      p = new PrintDocument();
      p.PrintPage += printPage;
      printPreviewDialog.Document = p;
      printPreviewDialog.ShowDialog();
    }
