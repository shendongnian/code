    Month current = Month.Jan; //staticly checking a month
            
    if(current == Month.Jan)
        MessageBox.Show("It's Jan");
    else
        MessageBox.Show("It's not Jan.");
    List<Month> specialMonthes = new List<Month>();
    specialMonthes.Add(Month.Oct);
    specialMonthes.Add(Month.Apr);
    specialMonthes.Add(Month.Jan);
    //Search the list for the month we are in now
    foreach (Month specialMonth in specialMonthes)
    {
        if ((int)specialMonth == DateTime.Now.Month) //dynamically checking this month
            MessageBox.Show(string.Format("It's {0} now & {0} is a special month.",  
                specialMonth));
            //Output: It's Jan now and Jan is a special month.
    }
