    private void InitializeGUI() 
    { 
        // Fill comboBox with countries 
        string[] countryNames = Enum.GetNames(typeof(Countries));
        foreach (string countryName in countryNames)
        {
            cmbCountries.Items.Add(countryName.Replace("_", " "));
        }
    } 
