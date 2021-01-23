    String strEntry = @"Thursday 18th of April 2013";
    DateTime dteValue = DateTime.MinValue;
    strEntry = strEntry.Replace("of", null);
    strEntry = strEntry.Replace("rd ", " ");
    strEntry = strEntry.Replace("th", null);
    strEntry = strEntry.Replace("st", null);
    DateTime.TryParse(strEntry, out dteValue);
    String strFormat = dteValue.ToString("dd/MM/yyyy");
    MessageBox.Show(strFormat, "Date Value", MessageBoxButtons.OK);
