    int i = 0;  // keep track of data in an instance variable 
    // this event is re-entrant. It will be called as long as HasMorePages = true;
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {    
        SolidBrush brush = new SolidBrush(Color.Black);
        Font font = new Font("Courier New", 12);
    
        float fontHeight = font.GetHeight();
        int startX = 40;
        int startY = 30;
        int lineperpage = 0;
    
        // removed
        //for (int i = 0; i < 100; i++)
        // print a page as long as their is space left AND data available
        while (lineperpage < 50 && i < 100)
        {
            e.Graphics.DrawString("Line: " + i, font, brush, startX, startY);
            startY += font.Height;
            lineperpage++;
       
            i++;  // next dataitem
        }
        e.HasMorePages = i < 100; // keep printing as long as there is date 
    }
