    protected void btnSend_Click(object sender, EventArgs e)
        {
            int age = -2;
            try
            {
                age = int.Parse(txtAge.Text);
                
                if (age <= 12)
                {
                    litResult.Text = "You are a child";
                }
            }
            catch (Exception e)
            {
                litResult.Text = "Entered values is not a number ";
            }
        }
