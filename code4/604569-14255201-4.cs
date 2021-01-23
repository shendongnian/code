    public class RegisterModel
    {
        ...
        private List<SelectListItem> _Categories = new List<SelectListItem>();
        
        private List<SelectListItem> Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }
    }
