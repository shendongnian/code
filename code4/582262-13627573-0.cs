    public DataTable JoinTable(DataTable piTable1, DataTable piTable2)
    {
        DataTable JoinTable = new DataTable();
        if (piTable1 == null || piTable2 == null)
            return new DataTable();
        var q = from parent in piTable1.AsEnumerable()
                         from child in piTable2.AsEnumerable()
                         select new 
                         {                                                      
                             property1 = parent.Field<T>("PropertyName1"),
                             property2 = parent.Field<T>("PropertyName2"),
                             property3 = child.Field<T>("PropertyName3"),
                             property4 = child.Field<T>("PropertyName4")
                         };
        JoinTable.Rows.Add(q);
        return JoinTable;
    }
