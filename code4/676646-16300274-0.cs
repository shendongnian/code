    List<MyData> lstData = new List<MyData>();
    List<dynamic> lst = new List<dynamic>();
    
                foreach (var item in lstData.Select(a => a.Date).Distinct())
                {
                    dynamic obj = new ExpandoObject();
                    obj.Date = item;
                    lst.Add(obj);
                }
    
                foreach (string item in lstData.Select(a => a.Name).Distinct())
                {
                    foreach (var objitem in lst)
                    {
                      string header = item;
                        ((IDictionary<String, Object>)objitem).Add(header, lstData.Where(d => d.Date == objitem.Date && d.Name == item).FirstOrDefault().Value);
                    }
                }
    gridView.Itemssource = lst;
