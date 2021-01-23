    var dt=new DataTable();
    dt.Columns.Add("id_staff",typeof(int));
    dt.Columns.Add("name_staff",typeof(string));
	
    var dt2=new DataTable();
    dt2.Columns.Add("id_staff",typeof(int));
    dt2.Columns.Add("name_staff",typeof(string));
	
    dt.Rows.Add(1,"test");
    dt2.Rows.Add(2,"test2");
    var result= 
    (
        from datatable1 in dt.AsEnumerable()
        select new
        {
           id_staff=datatable1.Field<int>("id_staff"),
           name_staff=datatable1.Field<string>("name_staff")
        }
    ).Concat
    (
        from datatable2 in dt2.AsEnumerable()
        select new
        {
           id_staff=datatable2.Field<int>("id_staff"),
           name_staff=datatable2.Field<string>("name_staff")
        }
     ).Dump();
