    namespace bankkk
    {
        public partial class FrmLogin : Form
        {
            public FrmLogin()
            {
                InitializeComponent();
            }
            ...
            int failedAttempts = 0;
            private void btnlogin_Click_1(object sender, EventArgs e)
            {
                valid = validate();
                if (!valid) {
                    //Increment the number of failed attempts
                    failedAttempts += 1;
                    
                    //If equal to 3
                    if (failedAttempts == 3) {
                        //Just close this window
                        this.Close();
                    }
                }
                else
                {
                    //the same code you were using...
                }
            }
        }
    }
