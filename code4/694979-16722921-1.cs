      protected void btnCheckCondition_Click(object sender, EventArgs e)
            {
                if (txtCondition.Text == "Show the button")
                {
                    btnSubmit.Visible = true;
                    lblMsg.Text = "You are allowed to see the button.";
                    
                }
                else
                {
                    lblMsg.Text = "You are NOT allowed to see the button.";
                   
                }
            }
