    DateTime date1= new DateTime();
    DateTime date2 = new DateTime();
    double days;
    
    bool isDate1Valid =DateTime.TryParse(textBox1.Text, out date1);
    bool isDate2Valid =DateTime.TryParse(textBox2.Text, out date2);
    
    if(isDate1Valid && isDate2Valid)
    days = (date1-date2).TotalDays;
