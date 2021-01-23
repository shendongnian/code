    public class MyEntityViewModel
    {
        private readonly MyEntity model;
    
        public MyEntityViewModel(MyEntity model)
        {
            this.model = model;
        }
    
        public int MyInt
        {
            get { return model. // some logic to retrieve int ... }
        }
    
        public string MyString
        {
            get { return model. // some logic to retrieve string ... }
        }
    }
