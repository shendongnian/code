    int Number = 0;
    int Total = 0;
    for (int size = 0; size < list.Count; size++)
    {
        Number = Convert.ToInt16(list[size].ToString());
        Total += Number;
    }
    int Final_Number = Total / 2;
