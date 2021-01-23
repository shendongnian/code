    DataTable dataTable = new DataTable("Letters");
    dataTable.Columns.Add("One");
    dataTable.Columns.Add("Two");
    dataTable.Rows.Add("AB", "Alpha Bravo");
    dataTable.Rows.Add("BC", "Bravo Charlie");
    dataTable.Rows.Add("CD", "Charlie Delta");
    dataTable.Rows.Add("DE", "Delta Echo");
    var cbLetters = new ComboBox();
    cbLetters.DataSource = dataTable.DataSet;
    cbLetters.DisplayMember = "Two";
    cbLetters.ValueMember = "One";
    cbLetters.Refresh();
    var foo = cbLetters.Items.Count;
    Console.Write(foo); //retun 0
