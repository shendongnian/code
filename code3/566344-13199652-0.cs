    public void CustPrinting() 
    {
       try 
         {
           strPrint = new StreamReader (filePath);
         try 
           {
             printFont = new Font("Arial", 10);
             PrintDocument pd = new PrintDocument(); 
             pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
             pd.PrinterSettings.PrinterName = printer;
             // Set the page orientation to landscape.
             pd.DefaultPageSettings.Landscape = true;
             pd.Print();
           } 
         finally 
         {
           strPrint.Close() ;
         }
       } 
       catch(Exception ex)
       { 
         MessageBox.Show(ex.Message);
       }
     }
