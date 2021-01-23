    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public List<UserInfo> mylist = new List<UserInfo>();
    public Form1()
    {
        InitializeComponent();
        for (int i = 0; i < 10; i++)
        {
            mylist.Add(new UserInfo() { Id = i, Name = "Name" + i, Description = "Description " + i });
        }
        lookUpEdit1.Properties.DataSource = mylist;
        lookUpEdit1.Properties.DisplayMember = "Name";
    }    
