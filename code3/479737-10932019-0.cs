    List<ShipmentInfo> si = new List<ShipmentInfo>();
    si.Add(new ShipmentInfo(orderedData.First()));
    for (int index = 1; index < orderedData.Count(); ++index)
    {
        if (orderedData.ElementAt(index).Start == 
            (si.ElementAt(si.Count() - 1).End + 1))
        {
            si[si.Count() - 1].End = orderedData.ElementAt(index).End;
        }
        else
        {
            si.Add(new ShipmentInfo(orderedData.ElementAt(index)));
        }
    }
    FinalResults.AddRange(si);
