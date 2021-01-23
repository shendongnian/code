    class FluentTable 
    {
      //as a dumb example I'm using a list
      //use whatever structure you need to store your items
      List<string> myTables = new List<string>();
      
      public FluentTable addTableCellwithCheckbox(string chk, bool isUnchecked, 
                                                            bool  isWithoutLabel)
      {
        this.myTables.Add(chk);
        //store other properties somewhere
        return this;
      }
    
      public FluentTable addTableCellwithTextbox(string name, bool isEditable)
      {
        this.myTables.Add(name);
        //store other properties somewhere
        return this;
      }
      public static FluentTable New()
      {
        return new FluentTable();
      }
    }
