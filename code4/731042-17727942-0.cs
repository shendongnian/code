     DateTime result;
       
    
     if (DateTime.TryParse("31/1/2010", System.Globalization.CultureInfo.GetCultureInfo("en-gb"), 
            System.Globalization.DateTimeStyles.None, out result))
                MessageBox.Show(result.ToShortDateString());    
        else
                MessageBox.Show("Not in Great Britain format");    
