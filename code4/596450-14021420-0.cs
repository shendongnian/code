     protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
          
            if (cmb_control.SelectedItem != null)
            {
                Control cntrl = Page.LoadControl("~/" + cmb_control.SelectedItem.Value);
                cntrl.ID = "_new_ctrl" + cmb_control.SelectedItem.Value;
               
                pnl_main.Controls.Clear();
                pnl_main.Controls.Add(cntrl);
            }
              
        }
