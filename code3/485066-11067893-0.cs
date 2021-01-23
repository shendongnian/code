        private void doc_PrintPage(Object sender, PrintPageEventArgs ev)
         {
           ev.Graphics.Clear(Color.White);
           int numofpages = (int)Math.Ceiling((double)(120/ 29.0)); // I changed here for testing
                    currentpage++;
                    if (currentpage == 1)
                        pagesleft = numofpages;
                    // Print some graphics onto ev.Graphics
                    pagesleft--;
             if (currentpage != numofpages && currentpage < numofpages && pagesleft > 0 && pagesleft != 0)
                    {
                        ev.HasMorePages = true;
                    }
                    else
                    {
                        ev.HasMorePages = false;
                    }
                }
    
