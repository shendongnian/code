    for (int i = 0; i < ListView2.Items.Count; i++)
    {
       var ucastCheckBox = (CheckBox)ListView2.Items[i].FindControl("UcastCheckBox");
       var brankyTextBox = (TextBox)ListView2.Items[i].FindControl("BrankyTextBox");
       // .ToString(), not .ToString
       // and int.Parse to get an int value from the string
       int brankyValue = int.Parse(brankyTextBox.ToString());
       
       if (ucastCheckBox.Checked || brankyValue > 0)
       {
       }
    }
