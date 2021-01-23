    using (MyDC TheDC = new MyDC())
    {
      DBTable TheTable;
      foreach (MyObject TheObject in TheListOfMyObjects)
      {
        TheTable = new DBTable();  
        TheTable.Prop1 = TheObject.Prop1;
        TheTable.Prop2 = TheObject.Prop2; 
        // only 2 properties, an int and a string
      }
      TheDC.DBTables.InsertAllOnSubmit(TheTable);
      TheDC.SubmitChanges();
    }
   
