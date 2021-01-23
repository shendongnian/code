    public partial class Form2 : Form
    {
        public User MyUser { get; set; }
        public Form2(User user)
        {
            InitializeComponent();
            MyUser = user;
        }
    }
