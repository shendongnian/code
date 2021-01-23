    public partial class Form3 : Form
    {
        static Form1 f1;
        static Form2 f2;
        public Form3()
        {
            InitializeComponent();
        }
        
        public static void InitForms(Form1 f1a, Form2 f2a)
        {
            f1 = f1a;
            f2 = f2a;
        }
      
        private void Form3_Load(object sender, EventArgs e)
        {   
            //use f1 and f2...
        }
    }
