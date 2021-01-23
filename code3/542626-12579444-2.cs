    public static bool HasData(int id)
    {
        MyDataContext dc = new MyDataContext ();
        return (from s in dc.Str_table 
                where s.sId == id 
                select s.AgeLengths.Any())
               .FirstOrDefault();
    }
