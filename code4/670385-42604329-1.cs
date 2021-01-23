    public partial class Form1 : Form
    {
        public static Form1 instance = null;
    
        public Form1()
        {
            instance = this; //add this class to singleton
            InitializeComponent();
        }
    
    
        public void Show(string Message)
        {
           MyConsole.Text = Message;
        }
