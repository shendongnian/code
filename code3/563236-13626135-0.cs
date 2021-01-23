      public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
            private void btnPress_Click(object sender, EventArgs e)
            {
                try
                {
                    for (int i = 1; i < 21; i++)
                    {
                     wsCall.Service1SoapClient CallWebService = new wsCall.Service1SoapClient();
                     lstBox.Items.Add(CallWebService.getNumber(i).toString());
                  
    
    // Changed Code Like this
    
        
                        //lstBox.Items.Add(i);
        
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception caught.");
                }
            }
        }
