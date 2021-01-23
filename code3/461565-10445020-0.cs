    private void InitializeGUI()
    {
        // Fill comboBox with countries
        cmbCountries.Items.AddRange(Enum.GetNames(typeof(Countries))
            .Select(c => c.Replace("_", " "))); 
    }
