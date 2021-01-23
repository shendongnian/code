    public static class SelectListextensions
    {
    
        public static System.Web.Mvc.SelectList SetSelectedValue
    (this System.Web.Mvc.SelectList list, string value)
        {
            if (value != null)
            {
                var selected = list.Where(x => x.Text == value).FirstOrDefault();
                selected.Selected = true;                
            }
            return list;
        }    
    }
