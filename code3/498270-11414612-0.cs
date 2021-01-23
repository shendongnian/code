    public partial class UserControl1 : UserControl
    {
        public ObservableCollection<string> Combolist { get; private set; }
        public UserControl1()
        {
            this.Combolist = new ObservableCollection<string>();//just initialize once!
            InitializeComponent();
            //if you wanna load new data, call .Clear() before
            //this.Combolist.Clear();
            //MySqlCommand status_db = new MySqlCommand("select name_ru from request_status", conn);
            //MySqlDataReader combodata = status_db.ExecuteReader();
            //while (combodata.Read())
            //{
            //    Combolist.Add(combodata.GetString(0));
            //}
            //test
            this.Combolist.Add("qqqq");
            this.Combolist.Add("wwww");
            this.Combolist.Add("eeee");
            this.Combolist.Add("rrrr");
            this.DataContext = this;
        }
    }
