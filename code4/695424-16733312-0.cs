    private List<Lot> CopyList(List<Lot> list)
    {
       List<Lot> clone = new List<Lot>();
    
       foreach(Lot l in list)
       {
          List<Wafer> wafers = new List<Wafer>();
          foreach(Wafer w in l.Wafers)
             wafers.Add(new Wafer(){ WaferName = w.WaferName });
    
          clone.Add(new Lot(){ LotName = l.LotName, Wafers = wafers });
       }
       
       return clone;
    }
