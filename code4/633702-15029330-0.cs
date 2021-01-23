    private void cb_Session_SelectedValueChanged(object sender, EventArgs e)
    {
      if(cb_Session.SelectedValue>-1)
       {
        listbox_Sessions.Visible = true;
        LoadSessionListbox();
       }
    
    }
