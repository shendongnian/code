    void MyDropDown_SelectedIndexChanged(Object sender, EventArgs e)
    {
      var selectedValue = ((DropDownList)sender).SelectedValue;
      if (!string.IsNullOrEmpty(textbox1.Text))
        textbox1.Text = selectedValue;
      else if (!string.IsNullOrEmpty(textbox2.Text))
        textbox2.Text = selectedValue;
      ...
    }
