    var totals=new Dictionary<int,int>
    foreach(string s in input)
    {
      string[] parts=s.Split(':');
      int id=int.Parse(parts[0]);
      int quantity=int.Parse(parts[0]);
      int totalQuantity;
      if(!totals.TryGetValue(id,out totalQuantity))
          totalQuantity=0;//Yes I know this is redundant
      totalQuanity+=quantity;
      totals[id]=totalQuantity;
    }
    var result=new List<string>();
    foreach(var pair in totals)
    {
      result.Add(pair.Key+":"+pair.Value);
    }
