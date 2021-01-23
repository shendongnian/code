    // Print the file.
         public void Printing()
         {
             try 
             {
                streamToPrint = new StreamReader (filePath);
                try 
                {
                   printFont = new Font("Arial", 10);
                   PrintDocument pd = new PrintDocument(); 
                   pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                   // Print the document.
                   pd.Print();
                } 
                finally 
                {
                   streamToPrint.Close() ;
                }
            } 
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
         }
