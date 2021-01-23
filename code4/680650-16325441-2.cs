    namespace WebApplication2
    {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
                //Page.Validate();
                if (Page.IsValid)
                {
                    int s = Convert.ToInt32(txtCustomerID.Text);
                }
            }
        }
    }
