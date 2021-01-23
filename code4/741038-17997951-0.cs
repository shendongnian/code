    public partial class Form1 : Form
    {
        User user1 = new User("abc","cde");
        public Form1()
        {
            InitializeComponent();
            new Form2(user1);
        }
    }
    
    public partial class Form2 : Form
    {
        User user1;
        public Form2(User u)
        {
            InitializeComponent();
            user1 = u;    
        }
    }
