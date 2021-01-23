    //Event in MasterPage
    public delegate void SomethingSelected(object sender, String SelectedValue);
    public event SomethingSelected OnSomethingSelected;
    //SelectedIndexChanged event in MasterPage
    protected void DropDonwnList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        OnSomethingSelected(sender, ((DropDownList)sender).SelectedValue);
    }
