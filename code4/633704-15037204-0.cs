    private void cb_Session_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cb_Session.SelectedValue == null) return;
        if (cb_Session.SelectedIndex == -1) return;
        listbox_Sessions.Visible = true;
        LoadSessionListbox((int)cb_Session.SelectedValue);
    }
    
    private void LoadSessionListbox(int selectedValue)
    {
       //TODO: Do stuff
    }
