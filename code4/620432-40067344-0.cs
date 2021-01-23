    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Rego No", typeof(string)));
     foreach (var item in list)
      { 
        dt.Columns.Add(new DataColumn(string.Format("{0:dd/MM}",item),typeof(string)));
        //enter code here 
    
    dlcalender.Columns.Add(string.Format("{0:dd/MM}",item), string.Format("{0:dd/MM}",item));
      }
    dlcalender.DataSource = dt;
    dlcalender.DataBind();
