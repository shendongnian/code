    public partial class Form1 : Form
        {
    
            private List<UserDataModel> userData = new List<UserDataModel>();
    
            public Form1()
            {
                InitializeComponent();
                MyInit();
            }
    
            public void MyInit()
        {
            var mymodel = new UserDataModel("Derek", "999-999", new HomeDataModel("Sesame Street", 111, 222));
            
            var mymodel1 = new UserDataModel("John", "999-999", new HomeDataModel("Tin Can Alley", 333, 444));
    
            userData.Add(mymodel);
            userData.Add(mymodel1);
    
            BindingSource bs = new BindingSource();
            bs.DataSource = userData;
    
            comboBox1.DataSource = bs;
            comboBox1.DisplayMember = "Home.StreetName";
           
        }
    }
    
    internal sealed class UserDataModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public HomeDataModel Home { get; set; }
    
        public UserDataModel()
        {
    
        }
    
        public UserDataModel(string name, string phone, HomeDataModel home)
        {
            this.Name = name;
            this.Phone = phone;
            this.Home = home;
        }
    }
    
    internal sealed class HomeDataModel
    {
        public string StreetName { get; set; }
        public int GeoLocationX { get; set; }
        public int GeoLocationY { get; set; }
    
        public HomeDataModel()
        {
    
        }
    
        public HomeDataModel(string streetname, int x, int y)
        {
            this.StreetName = streetname;
            this.GeoLocationX = x;
            this.GeoLocationY = y;
    
        }
    }
