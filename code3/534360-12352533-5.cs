    public class MyViewModel
    {
        public string Country { get; set; }
        [RequiredIf("Country", "usa", ErrorMessage = "Please select a state")]
        public string State { get; set; }
        public IEnumerable<SelectListItem> Countries
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "fr", Text = "France" },
                    new SelectListItem { Value = "usa", Text = "United States" },
                    new SelectListItem { Value = "spa", Text = "Spain" },
                };
            }
        }
        public IEnumerable<SelectListItem> States
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "al", Text = "Alabama" },
                    new SelectListItem { Value = "ak", Text = "Alaska" },
                    new SelectListItem { Value = "az", Text = "Arizona" },
                };
            }
        }
    }
