    public partial class Form2 : Form
    {
        private User _user;
        public User TheUser
        {
            get
            {
                return _user;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(User theUser)
        {
            _user = theUser;
        }
    }
