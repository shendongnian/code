    public class MyViewModel
    {
        public string SelectedType { get; set; }
        public IEnumerable<SelectListItem> Types
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "0", Text = "Single" },
                    new SelectListItem { Value = "1", Text = "Married" },
                };
            }
        }
    }
