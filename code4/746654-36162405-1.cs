    public static class Enum<T>
    {
        //usage: var lst =  Enum<myenum>.GetSelectItems();
        public static List<SelectListItem> GetSelectItems()
        {
            return  Enum.GetValues( typeof(T) )
                    .Cast<object>()
                    .Select(i => new SelectListItem()
                                 { Value = ((int)i).ToString()
                                  ,Text = i.ToString() })
                    .ToList();
        }
    
    }
