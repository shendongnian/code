        protected void btnNew_Click(object sender, EventArgs e) 
        {
            EnableAllRadioSubControls(Panel1);
        }
        protected void EnableAllRadioSubControls(Control ccontrol)
        {
            foreach (Control c in ccontrol.Controls)
            {
                if(c.Controls.Count > 0)
                {
                    EnableAllRadioSubControls(c);
                }else{
                    if (c is RadioButton)
                    {
                        if (((RadioButton)c).Enabled == false)
                        {
                            ((RadioButton)c).Enabled = true;
                        }
                    }
                }
            }
        }
