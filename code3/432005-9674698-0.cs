    using(var db = new MyEntities())
    {
        var sql = db.TestB.Include("TestA");
        var data = sql.ToList();
        //the var data will now contain the queried data.
        //you could bind the var to a datagrid. 
        
        //WPF datagrid
        MydataGrid.DataContext = data;
        //Asp.net datagrid
        MyDatagrid.DataSource = data;
        MyDatagrid.DataBind();
        //Or loop thru the results
        foreach(var item in data)
        {
             MessageBox.Show("Column -> " + item.ColumnName);
        }
    }
