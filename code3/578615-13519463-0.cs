    //using System.Globalization;
    DateTime myDate;
    if(DateTime.TryParseExact(textBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyle.None, out myDate)){
        //do something 
    }
