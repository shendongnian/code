            protected void rb_select_sign_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (rb_select_sign.SelectedValue == "0")
                {
                    pnl_PageNew_UC.Visible = true;
                    pnl_sign.Visible = false;
    
                }
                else
                {
                    pnl_PageNew_UC.Visible = false;
                    pnl_sign.Visible = true;
    
                }
    
                UpdatePanel1.Update();
            }
