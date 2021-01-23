    public partial class Form1 : Form
        {    
            public Form1()
            {
                InitializeComponent();
                this.Load += new EventHandler(Form1_Load);
            }
    
            void Form1_Load(object sender, EventArgs e)
            {
                funcA();
                funcB();
            }
    
            private void funcA()
            {
                button1.Click += new EventHandler(button1_Click);
            }
    
            private void funcB()
            {
                button1.Click += new EventHandler(button1_Click);
            }
    
            void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("I am in event handler");
            }
    
        }
