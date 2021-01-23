    public List<SelectListItem> GetPriorities()
    {
      List<SelectListItem> prioList=new List<SelectListItem>();
      prioList.Add(new SelectListItem { Text = "High", Value = "1" });
      prioList.Add(new SelectListItem { Text = "Low", Value = "2" });
      // to do :read from db and add to list instead of hardcoding
      return prioList;
    }
