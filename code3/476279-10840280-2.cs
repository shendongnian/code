    public static class SelectLists
        {
            public static IList<SelectListItem> BusinessUnits(IList<string> bussinessUnits, bool addEmpty, string selected = "")
            {
                var list = new List<SelectListItem>();
                if(addEmpty) list.Add(new SelectListItem());
                list.AddRange(bussinessUnits.Select(businessUnit => new SelectListItem {Selected = selected == businessUnit, Text = businessUnit, Value = businessUnit}));
    
                return list;
            }
        }
