    public int Add(Request item)
    {
        if (item != null)
        {
            var req = list.SingleOrDefault(r =>
                                  (r.LineID == item.LineID) &&
                                  (r.PartNo == item.PartNo) &&
                                  (r.ReasonID == item.ReasonID) &&
                                  (r.TypeID == item.TypeID)
                );
            if(req!=null)
            {
                req.Qty += item.Qty;
                return list.IndexOf(req);
            }
            list.Add(item);
            return list.Count - 1;
        }
        return -1;
    }
