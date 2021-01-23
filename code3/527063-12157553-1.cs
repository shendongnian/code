    public class MyModel
    {          
        [HiddenInput(DisplayValue = false)]
        public Guid? DepartmentId { get; set; }
    
        public string Caption { get; set; }
        public string Owner { get; set; }
        public bool Enabled { get; set; }
    }
