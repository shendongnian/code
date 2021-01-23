    public class MyViewModel
    {
        public MyViewModel()
        {
            Departments = Enumerable.Empty<SelectListItem>();
        }
        public int? SchoolId { get; set; }
        public IEnumerable<SelectListItem> SchoolList
        {
            get
            {
                // TODO: fetch the schools from a DB or something
                return new[]
                {
                    new SelectListItem { Value = "1", Text = "school 1" },
                    new SelectListItem { Value = "2", Text = "school 2" },
                };
            }
        }
        public int? DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
