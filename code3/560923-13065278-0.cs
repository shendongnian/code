    var matched = (from table1 in dt4.AsEnumerable()
                      join table2 in oltlb.AsEnumerable() on
                    table1.Field<int>("ID") equals table2.Field<int>("ID")
                      where table1.Field<string>("Data") == table2.Field<string>("Data")
                      select table1);
          DataTable dthi5 = new DataTable();
          dthi5 = matched.CopyToDataTable();
    myGridView.DataSource = dthi5;
    myGridView.DataBind();
