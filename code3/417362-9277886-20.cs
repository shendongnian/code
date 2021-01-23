    public class MyViewModel
    {
        [Required]
        public string SelectedOption { get; set; }
        public IEnumerable<SelectListItem> Options
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "1", Text = "item 1" },
                    new SelectListItem { Value = "2", Text = "item 2" },
                };
            }
        }
        [RequiredIf("SelectedOption", "2")]
        public string RadioButtonValue { get; set; }
        [RequiredIf("SelectedOption", "1")]
        public string Input1 { get; set; }
        [RequiredIf("SelectedOption", "1")]
        public string Input2 { get; set; }
    }
