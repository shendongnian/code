    public int Add(Request item) {
        if (item != null) {
          foreach (var x in list.Where(r => 
            (r.LineID == item.LineID) &&
            (r.PartNo == item.PartNo) &&
            (r.ReasonID == item.ReasonID) &&
            (r.TypeID == item.TypeID)
            ).ToList()) {
            x.Qty += item.Qty;
            return list.IndexOf(x);
          }
          list.Add(item);
          return list.Count - 1;
        }
        return -1;
      }
