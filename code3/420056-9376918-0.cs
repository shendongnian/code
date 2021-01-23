    protected void Sc_submit_button_Click(object sender, ImageClickEventArgs e)
    {
    PhoneLbl.Visible = false;
    if (Page.IsValid == true)
        {
                if (txt_phonenumber.Text != string.Empty || txt_mobilenumber.Text != string.Empty)
                  {
                        // any code }
                  }
               else 
                  {
                    Sc_submit_button.Enabled = true;
                    PhoneLbl.Visible = true;
				    MobileLbl.Visible = true;
				    txt_phonenumber.Focus();
                    return;
                  }
        }
    }
