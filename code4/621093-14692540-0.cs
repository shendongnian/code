    public class MyViewModel
    {
        public DropDown1 DropDownA { get; set; }
        public DropDown2 DropDownB { get; set; }
        public Model ModelData { get; set; }
    }
    public class DropDown1
    {
        public int SelectedValue { get; set; }
        public List<T> DropDownValues { get; set; }
    }
    public class DropDown2
    { 
        public int SelectedValue { get; set; }
        public List<T> DropDownValues { get; set; }
    }
