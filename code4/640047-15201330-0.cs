    public class Place
    {
        public string City{get;set;}
        public SelectListItem[] Cities()
        {
            return new SelectListItem[2] { new SelectListItem() { Text = "London" }, new SelectListItem() { Text = "New York" } };
        }
    }
