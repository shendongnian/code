    public partial class Form1 : Form
    {
        MyProcess myProcess = null;
        public Form1()
        {
            InitializeComponent();
            myProcess = new MyProcess
            {
                MyButton = button1
            };
        }
    }
