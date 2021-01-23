    private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        if( (int)e.Graphics.MeasureString("m", txtMain.Font).Width > 0 )
        {
            int charPerLine = 
                e.MarginBounds.Width / (int)e.Graphics.MeasureString("m", txtMain.Font).Width;
        }
    }
