    static void Main(string[] args)
    {
        Program p = new Program();
        DataTable dt1= p.Get1();
        DataTable dt2 = p.Get2();          
        DataTable dt3 = p.Get3(dt1, dt2);
    }
    public DataTable Get1()
    {
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("ID");
        dt1.Columns.Add("Name");
        dt1.Rows.Add("1", "JOHN");
        dt1.Rows.Add("2", "GEORGE");
        dt1.Rows.Add("3", "RAGU");        
        return dt1;
    }
    
    public DataTable Get2()
    {
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("AGE");         
        dt2.Rows.Add("23");
        dt2.Rows.Add("23");
        dt2.Rows.Add("22");
        return dt2;
    }
    
    public DataTable Get3(DataTable dt1,DataTable dt2)
    {
        dt1.Columns.Add("Age");
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            dt1.Rows[i]["Age"] = dt2.Rows[i]["Age"];
        }
        return dt1;
    }
