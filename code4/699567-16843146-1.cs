      private List<Excel.Worksheet> _Worksheets = new List<Excel.Worksheet>();
    
      private void ThisWorkbook_Startup(object sender, System.EventArgs e)
      {
       foreach (Excel.Worksheet sheet in Worksheets) //Could test for sheet name here
       {
        _Worksheets.Add(sheet);
        sheet.SelectionChange += 
            new Excel.DocEvents_SelectionChangeEventHandler(Sheet_SelectionChange);
       }
      }
