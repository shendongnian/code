    DataTable dataTable = new DataTable("Letters");
    dataTable.Columns.Add("One");
    dataTable.Columns.Add("Two");
    dataTable.Rows.Add("AB", "Alpha Bravo");
    dataTable.Rows.Add("BC", "Bravo Charlie");
    dataTable.Rows.Add("CD", "Charlie Delta");
    dataTable.Rows.Add("DE", "Delta Echo");
    
    var cbLetters = new DropDownList();
    cbLetters.DataSource = dataTable.DefaultView;
    cbLetters.DataSource = new BindingSource(dataTable, null);
    cbLetters.DataValueField = "one";
    cbLetters.DataTextField = "two";
    cbLetters.DataBind();  // Here DataBind  
    cbLetters.SelectedIndex = 2;
    //cbLetters.Refresh();
    Console.Write("value selected -> " + cbLetters.SelectedValue); //return CD
    Console.Write("text selected -> " + cbLetters.SelectedItem.Text); // return Charlie Delta
