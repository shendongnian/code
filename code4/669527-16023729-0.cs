    private void tempC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tempC.Text = "")
               return;
            tempC.MaxLength = 3;
            Temperature T = new Temperature(celsius);
            T.temperatureValueInCelcius = Convert.ToDecimal(tempC.Text);
            celsius = Convert.ToDecimal(tempC.Text);
            T.ConvertToFarenheit(celsius);
            tempF.Text = Convert.ToString(T.temperatureValueInFahrenheit);
        }
