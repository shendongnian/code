    string value = string.Empty;
    for (int i = 0; i < 5; i++)
           {
               string str = " ";
               if (i < HoursByRate.Count())
                   str = HoursByRate[i];
               value += str + ((char)10).ToString() + ((char)13).ToString();
           }
    foreach (var SEVTs in query)
    {
        SEVTs.USER3 = value;
     }
