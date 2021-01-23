    //new list of lists to hold new information.
    List<List<Descendants>> NewList = new List<List<Descendants>>();
    foreach (var item in Data.Descendants.GroupBy(x => x.Attribute("v").Value))
    {
         NewList.Add(item.ToList());
    }
