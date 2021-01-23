    public partial class User : BaseModel
    {
        private int _id;
        public int Id 
        { 
            get { return _id; } 
            set { SetProperty(ref _id , value);} 
        }
        private string _name;
        public string Name 
        { 
            get { return _name; } 
            set { SetProperty(ref _name , value);}
        } 
    }
