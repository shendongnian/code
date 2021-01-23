    private List<Lot> CopyList(List<Lot> lotList)
    {
        List<Lot> result = new List<Lot>();
    
        for (int i = 0; i < lotList.Count; i++)
        {
             Lot lot = new Lot();
             lot.LotName = lotList[i].LotName;
             lot.Wafers = new List<Wafer>(lotList[i].Wafers);
             result.Add(lot);
        }
    
        return result;
    }
