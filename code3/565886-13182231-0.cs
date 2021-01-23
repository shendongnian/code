    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        public event Action<string> MyEvent; //TODO give better name and set arguments for the Action
    
        private void button1_Click(object sender, EventArgs e)
        {
            string someValue = "Hello World!";  //TODO get value that you want to share
    
            if (MyEvent != null)
            {
                MyEvent(someValue);
            }
        }
    }
