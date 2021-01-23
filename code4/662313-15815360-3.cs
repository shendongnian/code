    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                userControl11.OnButtonClicked += userControl11_OnButtonClicked;
            }
    
            void userControl11_OnButtonClicked(object sender, EventArgs e)
            {
                MessageBox.Show("got here");
            }
    
             
            }
        }
