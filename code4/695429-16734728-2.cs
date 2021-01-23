    List<Lot> result = new List<Lot>(lotList.Count);
    foreach (Lot item in lotList)
    {
        result.Add(new Lot()
        {
            LotName = item.LotName,
            Wafers = new List<Wafer>(item.Wafers)
        });
    }
