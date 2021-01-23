    public static class Enum<T>
    {
        //usage: var lst =  Enum<myenum>.GetSelectList();
        public static List<SelectListItem> GetSelectList()
        {
            return  Enum.GetValues( typeof(T) )
                    .Cast<object>()
                    .Select(i => new SelectListItem()
                                 { Value = ((int)i).ToString()
                                  ,Text = i.ToString() })
                    .ToList();
        }
    
    }
