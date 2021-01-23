    DataGridViewComboBoxColumn buildCountries = new DataGridViewComboBoxColumn();
    buildCountries.HeaderText = "List of Countries";
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("Keys");
    dataTable.Columns.Add("Values");
    KeyValuePair<string, string> [] array = CountryList.ToArray();
    foreach(KeyValuePair<string, string> kvp in array)
    {
            dataTable.Rows.Add(kvp.Key, kvp.Value);
    }
    buildCountries.DataSource = dataTable;
    buildCountries.DisplayMember = "Values";
    buildCountries.ValueMember = "Keys";
    dataGridView1.Columns.Add(buildCountries);
