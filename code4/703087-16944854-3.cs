    private void InitializeSelAccTypeDesc()
    {
	SelAcctDescription[0] = "<p>This account type is for users who want to do something like this.</p>";
	SelAcctDescription[1] = "<p>This account type is for other users who want to do something like that.</p>";
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
	// get the selected account type
	AccTypeByte = Convert.ToByte(RadioButtonList1.SelectedValue.ToString());
          
          // notify the user with the value of the selected radio button
	NotifyLabel.Visible = true;
	NotifyLabel.Text = string.Format("{0} was the value selected.   -   ", AccTypeByte);
	// replace the html in the div with the html from the selected array element
	SelAccTypeDesc.InnerHtml = SelAcctDescription[Convert.ToInt32(AccTypeByte)];
    }
