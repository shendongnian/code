    private Expression<Func<Record, bool>> GetMonthBoolFunc(int value)
    {
        return a => (a.codedID/10000 == value); 
    }
    
    var q = openedDatabase.RecordTable.Where(GetMonthBoolFunc(1)); 
