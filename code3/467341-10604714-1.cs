    public class ViewModel
    {
        public List<SelectListItem> Departments
        {
            get;
            private set;
        }
        public Department Department { get; set; }
        public ViewModel()
        {
            Departments = new List<SelectListItem>();
            //Assume you'll be getting the list from db here?
            Departments .Add(new SelectListItem { Text = "HR", Value = "IdValueHere" });
            Departments .Add(new SelectListItem { Text = "IT", Value = "IdValueHere" });
        }
    }
