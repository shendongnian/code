    public class CheckBoxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CheckBox { get; set; }
    }
    
    public class ViewModel
    {
        public IPagination<CheckBoxViewModel> List { get; set; }
    }
