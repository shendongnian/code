    PersianCalendar p = new System.Globalization.PersianCalendar();
    DateTime today = DateTime.Today;
    DateTime pDate = new DateTime(p.GetYear(today), p.GetMonth(today), p.GetDayOfMonth(today), p);
    DateTime d2 = DateTime.Parse(textBox9.Text);
    // THIS NEEDS TO BE EXPLAINED
    textBox10.Text = (d2 - pDate).ToString().Replace(".00:00:00","");
