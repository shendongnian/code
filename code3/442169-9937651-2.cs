    void LinqToDatatable(string[] columns, Type[] datatypes, linqSource)
    {
         for loop
         {
           dt.columns.add(columns[i], datatypes[i]);
         }
    
    //Still thinking how to make this generic.. 
    var result = from p in in this.GetData().Cast<IContent>()             
                 select dt.LoadDataRow(
                    new object[] { string[0] = item.GetMetaData[string[0]],
                                   string[1] = item.GetMetaData[srring[1]
                     },
                    false);
    
    
    }
