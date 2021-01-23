    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 frm)
        {
            form1 = frm;
            InitializeComponent();
            
        }
        public void button1_Click(object sender, EventArgs e)
        {
            //Declaring the new instance of Form1 called 'form1'.
            //var form1 = new Form1();     
            this.Hide();
            form1.Show();
            form1.label1.Text = ("hello");
            MessageBox.Show(form1.ApplicationPort.BaudRate.ToString());
        }
    
        public void Form2_Load(object sender, EventArgs e)
        {
            //Declaring the new instancce for Form1 called 'form1'.
            MessageBox.Show(form1.ApplicationPort.BaudRate.ToString());
    
        }
    }
    public partial class Form1 : Form
    {
        //Making a refernce of Form2 called 'form2'.
        Form2 form2; // Pass the instance of this object to Form2!
    
        public Form1()
        {
            form2 = new Form2(this)
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            //Able to reference form2 in a style that replicated VB.NET
            form2.Show();
            this.Hide();
            form2.label2.Text = ("Hello2");
        }
    
        public void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ("Start!");
            ApplicationPort.BaudRate = 200;
        }
