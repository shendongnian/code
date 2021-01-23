    // The PrintPage event is raised for each page to be printed. 
    private void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        int row = 0;
        int col = 0;
        float xPos = 0;
        float yPos = 0;
        float leftMargin = ev.MarginBounds.Left;
        float topMargin = ev.MarginBounds.Top;
        string line = null;
        // Print each line of the file. 
        while (true)
        {
            try
            {
                row = Convert.ToInt32(streamToPrint.ReadLine());
                col = Convert.ToInt32(streamToPrint.ReadLine());
                line = streamToPrint.ReadLine();
            }
            catch
            {
                break;
            }
            xPos = leftMargin + (col * ev.Graphics.MeasureString(" ", printFont, ev.PageBounds.Width));
            yPos = topMargin + (row * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(line, printFont, Brushes.Black, xPos, yPos, new StringFormat());
        }
    }
        
