    EnumerableRowCollection<DataRow> result = 
                  from t1 in dt1.AsEnumerable()
                  join t1 in dt2.AsEnumerable()
                  on t1.Field<int>("KeyId") equals
                      t2.Field<int>("KeyId")
                  select new
                  {
                       KeyId = t1.Field<int>("KeyId"),
                       Column1 = t1.Field<string>("Column1"),
                       Column2 = t2.Field<string>("Column2"), 
                       .
                       . 
                  };
    dataGridView1.DataSource = result.AsDataView();
