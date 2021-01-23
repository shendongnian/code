    // set to false before calling PrintDocument.Print()
    bool firstPagePrinted = false;
    private void printdocument_PrintPage(object sender, PringPageEventArgs e)
    {
      if(!firstPagePrinted)
      {
        // TODO: whatever you want
        e.Graphics.DrawString("Header page", printFont, 
          Brushes.Black, e.MarginBounds.left, e.MarginBounds.Top, new StringFormat();
        firstPagePrinted = true;
        e.HasMorePage = true;
      }
      // do 2nd and subsequent pages here...
    }
