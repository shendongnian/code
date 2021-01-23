    protected void GWCase_SelectedIndexChanged(object sender, EventArgs e)
    {
      int idx = GWCase.SelectedIndex; //add this line in
      string detail = GWCase.DataKeys[idx].Values[0].ToString();
      string propertydetail = GWCase.DataKeys[idx].Values[1].ToString();
      string suspectdetail = GWCase.DataKeys[idx].Values[2].ToString();
      tbdetails.Text = detail;
      tbproperty.Text = propertydetail;
      tbsuspect.Text = suspectdetail;
    }
