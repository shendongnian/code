    var topGroup = classes.GroupBy(c => c.SubFormId)
                          .OrderByDescending(sf => sf.Count())
                          .FirstOrDefault();
              
    if(topGroup!=null)
      subForm = item.First().SubForm;
