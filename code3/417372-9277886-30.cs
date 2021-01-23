        [Validator(typeof(MyViewModelValidator))]
        public class MyViewModel
        {
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
            public string RadioButtonValue { get; set; }
            public string Input1 { get; set; }
            public string Input2 { get; set; }
        }
