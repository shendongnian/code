    void ButtonAddCity_Click(object sender, EventArgs e)
    {
        cities.Add(new City() {
            Name = nameTextBox.Text,
            Country = countryTextBox.Text, 
            CountryCode = codeTextBox.Text,
            State = stateTextBox.Text
        }); 
    }
