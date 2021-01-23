        var model = new DataViewModel()
        model.Rows = new List<MyRow>();
        DataTable dt = con.GetQAData();
        int i = 1;
        foreach (DataRow dr in dt.Rows)
        {
           var row = new MyRow();
           /* populate the the MyRow class */
           Rows.Add(row);
        }
