        public class MyViewModel
        {
            public string Value { get; set; }
            public IEnumerable<SelectListItem> Items
            {
                get
                {
                    return new[]
                    {
                        new SelectListItem { Value = "1", Text = "item 1" },
                        new SelectListItem { Value = "2", Text = "item 2" },
                        new SelectListItem { Value = "3", Text = "item 3" },
                    };
                }
            }
        }
