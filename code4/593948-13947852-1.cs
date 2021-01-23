    //Add an event handler for the Change event of both worksheet objects.
       EventDel_CellsChange = new Excel.DocEvents_ChangeEventHandler( CellsChange);
       
       xlSheet1.Change += EventDel_CellsChange;
    private void CellsChange(Excel.Range Target )
    {
       //This is called when any cell on a worksheet is changed.
       Debug.WriteLine("Delegate: You Changed Cells " + 
          Target.get_Address( Missing.Value, Missing.Value, 
          Excel.XlReferenceStyle.xlA1, Missing.Value, Missing.Value ) + 
          " on " + Target.Worksheet.Name);
    }
