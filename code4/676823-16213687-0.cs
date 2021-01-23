    string[] IntType ={"Byte","Decimal","Double","Int16","Int32","SByte",
                    "Single","UInt16","UInt32","UInt64"};
    static void Main(string[] args)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("num", typeof(int));
        dt.Columns.Add("str", typeof(string));
        Program p=new Program();
        string type = dt.Columns["num"].DataType.Name;
        if (p.IntType.Contains(type))
        {
            //True
        }
               
    }
