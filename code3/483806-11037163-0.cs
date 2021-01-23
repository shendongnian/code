    public int Add(Request item) {
        if (item != null)
        {
            int ind = list.IndexOf(item);
            if (ind == -1)
            {
                list.Add(item);
                return list.Count - 1;
            }
            else
            {
                list[ind].Qty += item.Qty;
                return ind;
            }                
        }
        return -1;
    }
