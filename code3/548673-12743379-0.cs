    public partial class Form1: Form
    {
            public Form1()
            {
                InitializeComponent();
                this.Load += new EventHandler(Form1_Load);
                radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
                radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            }
    
            void radioButton_CheckedChanged(object sender, EventArgs e)
            {
                RadioButton rb = (RadioButton)sender;
                if(rb.Checked)
                    MessageBox.Show(rb.Text); //Shows whatever Text your radiobutton has
            }
    
            void Form1_Load(object sender, EventArgs e)
            {
            }
    }
