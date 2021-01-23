    public partial class Form3 : Form {
        public string setCodes
        {
            get { return test1.Text; }
            set { test1.Text = value; }
        }
        private A a;
        public Form3()
        {
            InitializeComponent();
            a = new A(this);
        } 
        private void button1_Click(object sender, EventArgs e)
        {            
            a.b();            
        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
    
    public class A
    {       
        private Form3 v;
        public a(Form3 v)
        {
            this.v = v;
        }
        public void b()
        {
            v.setCodes = "abc123";
        }
    }    
