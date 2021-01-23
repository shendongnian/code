    public class TestModel
    {
        public string Gender { get; set; }
        public IEnumerable<SelectListItem> GenderList
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem> { new SelectListItem() { Text = "Select", Value = "Select" }, new SelectListItem() { Text = "Male", Value = "Male" }, new SelectListItem() { Text = "Female", Value = "Female" } };
                return list.Select(l => new SelectListItem { Selected = (l.Value == Gender), Text = l.Text, Value = l.Value });
            }
        }
    }
