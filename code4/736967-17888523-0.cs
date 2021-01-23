    public static T GetDataItem<T>(this DataTable dTable, int idToMatch, 
                                   string fieldToMatchIdTo, string fieldToReturn)  
    {  
        var result = dTable.AsEnumerable()  
                           .Where(r => r.Field<int>(fieldToMatchTo) == idToMatch)
                           .FirstOrDefault();
        if (result == null)
        {
            return default(T);
        }
        else
        {
            return result.Field<T>(fieldToReturn);
        }
    }
