    Parallel.ForEach(list, () => DateTime.MinValue, (l, state, date) =>
    {
        date = new DateTime(l.Ticks+5000);
        return date;
    },
    finalresult =>
    {
       lock (newList)
       {
           newList.Add(finalresult);
       }
    });
