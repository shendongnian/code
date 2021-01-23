    public class ValueModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ValueDropDownModel> DropDown { get; set; }
    }
    public class ValueDropDownModel
    {
        [Range(0, 15)]
        public int DropDown { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> AvailableDropDown { get; set; }
    }
