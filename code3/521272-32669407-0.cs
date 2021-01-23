        if (!DateTime.TryParseExact(txtStartDate.Text, formats, 
                        System.Globalization.CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out startDate))
        {
            //your condition fail code goes here
            return false;
        }
        else
        {
            //success code
        }
