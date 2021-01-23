    // Setting up a dataset.  This dataset has no data; in real life you'd get the
    // data from somewhere else, such as a database, and wouldn't need to build it.
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("ID"));
    dt.Columns.Add(new DataColumn("Description"));
    ds.Tables.Add(dt);
    // Creating a list box. You'd probably have this declared in your HTML and wouldn't need to
    // create it.  
    ListBox listBox1 = new ListBox();
     
    listBox1.DataSource = ds.Tables[0];
    listBox1.DataValueField = "ID";
    listBox1.DataTextField = "Description";
    listBox1.DataBind();
