    List<string> dateList = new List<string>();
    foreach(sMedication temp in medicationList) 
    {
        if (!dateList.Contains(temp.StartDate.ToShortDateString()))
        {
            dateList.Add((temp.StartDate.ToShortDateString()));
        }
    }
    lstboxSchedule.ItemsSource = date
