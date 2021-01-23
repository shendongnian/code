    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (chkSaveView.Checked)
        {
            if (!string.IsNullOrEmpty(txtViewName.Text))
            {
                //some code here to save the view name from txtViewName to the DB
                //SingleSelectCustomDropDown obj22 = new SingleSelectCustomDropDown();//Do not create the control again
                obj22.PopulateOtherViews();
                Page.ClientScript.RegisterStartupScript(this.GetType(),"close","CloseWindow();",true);
    
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertEnterViewName", "alertMessage('Please enter the view name');", true);
            }
    
        }
    
    }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertEnterViewName", "alertMessage('Please enter the view name');", true);
            }
        }
    }
