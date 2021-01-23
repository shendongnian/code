    Image bmIm;
    private void PrintImage(Image img)
    {
      bmIm = img;
      PrintDocument pd = new PrintDocument();
      pd.OriginAtMargins = true;
      pd.DefaultPageSettings.Landscape = true;
      pd.Print();
    }
    void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
      double cmToUnits = 100 / 2.54;
      e.Graphics.DrawImage(bmIm, 0, 0,(float)(27 * cmToUnits),(float)(18 * cmToUnits));
    }
