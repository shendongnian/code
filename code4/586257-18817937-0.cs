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
            var userDataModel1 = new UserDataModel();
            userDataModel1.Name = "Mike";
            userDataModel1.Phone = "555-666";
            userDataModel1.Home = new HomeDataModel();
            userDataModel1.Home.StreetName = "MikeStreet";
            userDataModel1.Home.GeoLocationX = 111;
            userDataModel1.Home.GeoLocationY = 222;
            var userDataModel2 = new UserDataModel();
            userDataModel2.Name = "Jonathan";
            userDataModel2.Phone = "777-888";
            userDataModel2.Home = new HomeDataModel();
            userDataModel2.Home.StreetName = "JonathanStreet";
            userDataModel2.Home.GeoLocationX = 333;
            userDataModel2.Home.GeoLocationY = 444;
            userData.Add(userDataModel1);
            userData.Add(userDataModel2);
            // This works as usually:
            /*
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Home";
            comboBox1.DataSource = userData;
            */
            // But this works not (either with comboBox1.DataBindings.Add() nor with BindingSource):
            comboBox1.DisplayMember = "Home.StreetName";
            comboBox1.ValueMember = "Home";
            comboBox1.DataSource = userData;
            // To drive me crazy, THAT shit works:
            textBox1.DataBindings.Add("Text", userData, "Home.StreetName");
            /*
            So how can i use a String-Property of a SubObject as ComboBox-DisplayMember ???
            BTW: To rebuild the sample, you only need a normal Forms Application and
            then drop a ComboBox and a TextBox on it. Copy that code here, and run it.
            */
        }
        // To add this method - follow to my instructions below
        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((UserDataModel)e.ListItem).Home.StreetName;
        }
    }
    internal sealed class UserDataModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public HomeDataModel Home { get; set; }
    }
    internal sealed class HomeDataModel
    {
        public string StreetName { get; set; }
        public int GeoLocationX { get; set; }
        public int GeoLocationY { get; set; }
    }
