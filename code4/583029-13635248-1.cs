    Dictionary<string, string> CountryList=new Dictionary<string, string>();
    
    DataGridViewComboBoxColumn buildCountries = new DataGridViewComboBoxColumn();
    buildCountries.HeaderText = "List of Countries";
    buildCountries.DataSource = CountryList.ToArray();
    buildCountries.ValueMember = "Key";
    buildCountries.DisplayMember = "Value";
