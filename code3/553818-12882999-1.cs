    static  int cnt=0;
        protected void btnShowButtonText_Click(object sender, EventArgs e)
            {
        cnt++;
                if (cnt%2!=0)
                {
                    btnShowButtonText.Text = "Hide gift voucher details";
                    lblShowText.Visible = true;
                }
        if (cnt%2==0) 
                {
        
                    btnShowButtonText.Text = "Button";
                    lblShowText.Visible = false;
        
                }
            }  
