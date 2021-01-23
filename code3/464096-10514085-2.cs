    public partial class Form2 : Form
        {
            public string test 
            { 
               get { return label1.Text; }
               set { label1.Text = value ;} 
            }
    
            public Form2()
            {
                InitializeComponent();
            }
        }
