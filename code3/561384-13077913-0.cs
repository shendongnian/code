     public partial class Form1 : Form
     {
            Form2 form2;
            public Form1()
            {
                InitializeComponent();
                form2 = new Form2();
                form2.Show();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                bool labelVisible = form2.ToggleLabelVisibility();
            }
     }
    public partial class Form2 : Form
    {
         public Form2()
         {
            InitializeComponent();
         }
    
         public bool ToggleLabelVisibility()
         {
             label1.Visible = !label1.Visible;
             return label1.Visible;
         }
    }
