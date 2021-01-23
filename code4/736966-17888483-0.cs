     public static T GetDataItem<T>(this DataTable dTable, int idToMatch
                          ,string fieldToMatchIdTo, string fieldToReturn)  
     {  
    DataRow results = dTable.AsEnumerable()  
          .Where(r => r.Field`<int>`(fieldToMatchTo) == idToMatch).ToArray();  
    return (T)results[0][fieldToReturn];  
    }
