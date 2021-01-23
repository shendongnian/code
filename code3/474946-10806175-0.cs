    // This function is returning 2886 records      
    public List<tableC_POCO_Object> Get_TableC() 
    {
        return from tbla in Get_TableA()
               join tblb in Get_TableB() on tbla.Col1 equals tblb.Col1
               select new tableC_POCO_Object 
               {
                 Col1 = tblb.Col1,
                 Col2 = tbla.Col2
               }.Distinct().ToList();
    }
