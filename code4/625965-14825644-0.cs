    string value = string.Empty;
    for (int i = 0; i < 5; i++)
           {
               string str = " ";
               if (i < HoursByRate.Count())
                   str = HoursByRate[i];
               value += str + SqlFunctions.Char(10) + SqlFunctions.Char(13);
           }
    foreach (var SEVTs in query)
    {
        SEVTs.USER3 = value;
     }
