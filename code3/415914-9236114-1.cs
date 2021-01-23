    using (MyDC TheDC = new MyDC())
    {
      List<DBTable> TheTables = new List<DBTable>();
      foreach (MyObject TheObject in TheListOfMyObjects)
      {
        DBTable TheTable= new DBTable();  
        TheTable.Prop1 = TheObject.Prop1;
        TheTable.Prop2 = TheObject.Prop2; 
        // only 2 properties, an int and a string
        TheTables.Add(TheTable);
      }
      TheDC.DBTables.InsertAllOnSubmit(TheTables);
      TheDC.SubmitChanges();
    }
   
