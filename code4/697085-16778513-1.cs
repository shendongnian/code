    foreach(Control ctrl in yourform.Controls)
    {
        if(ctrl.GetType() == typeof(TextBox))
        {
            if (TextBox[i].Text == "")
            {
                days.Add("Restday");
            }
            else
            {
                days.Add(((TextBox)ctrl).Text);
            } 
        }
    }
