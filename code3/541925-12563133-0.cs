    void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
       var bitmap = GetNextLabel();
       if(bitmap != null)
       {
          e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
       }
       // Will print more pages as long as there are bitmaps
       e.HasMorePages = (bitmap != null);
    }
