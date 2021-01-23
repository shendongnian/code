    private StreamReader sr;
    public void OutputBtn_Click(object sender, EventArgs e)
    {
        foreach(var li in lb.Items)
        {
            PrintDocument PrintD = new PrintDocument();
            PrintD.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);
            sr = new StreamReader(li.ToString());
            PrintD.Print();        
        }
    }
    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs ev) 
    {
         float linesPerPage = 0;
         float yPos =  0;
         int count = 0;
         float leftMargin = ev.MarginBounds.Left;
         float topMargin = ev.MarginBounds.Top;
         String line = null;
         // Calculate the number of lines per page.
         linesPerPage = ev.MarginBounds.Height  / 
            printFont.GetHeight(ev.Graphics) ;
         // Iterate over the file, printing each line.
         while (count < linesPerPage && ((line = sr.ReadLine()) != null)) 
         {
            yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString (line, printFont, Brushes.Black, 
               leftMargin, yPos, new StringFormat());
            count++;
         }
         // If more lines exist, print another page.
         if (line != null) 
            ev.HasMorePages = true;
         else 
            ev.HasMorePages = false;
    }
