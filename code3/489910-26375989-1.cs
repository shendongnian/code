    public List<int> GetAllChild(int id,List<KeyValuePair<int, int>> newLst)
    {
          List<int> list = new List<int>();
          for (int i = 0; i < newLst.Count; i++)
          {
                if (Convert.ToInt32(newLst[i].Key) == id)
                {
                     if (!list.Contains(Convert.ToInt32(newLst[i].Value)))
                     {
                         list.Add(Convert.ToInt32(newLst[i].Value));
                         List<int> l = GetAllChild(newLst[i].Value, newLst);
                         list.AddRange(l);
                     }
                }
           }
           return list;
    }
