    public class MyViewModel
    {
        public string SelectedDepartment { get; set; }
        public string SelectedFunction   { get; set; }
        public IEnumerable<SelectListItem> Departments  { get; set; }
        public IEnumerable<SelectListItem> Functions    { get; set; }
        // Your old model
        public IEnumerable<MasterList> Master           { get; set;}
    }
