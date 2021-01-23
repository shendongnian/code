    public class MyViewModel
    {
        [Display(Name = "Marital status")]
        public string SelectedMaritalStatus { get; set; }
        public IEnumerable<SelectListItem> MaritalStatuses
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
