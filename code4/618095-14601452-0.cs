    public class TestViewModel
    {
        public IEnumerable<SelectListItem> TestListItems
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Item 1", Value = "1" },
                    new SelectListItem { Text = "Item 1", Value = "1" },
                    new SelectListItem { Text = "Item 1", Value = "1" },
                };
            }
        }
        public string SelectedItemValue { get; set; }
    }
