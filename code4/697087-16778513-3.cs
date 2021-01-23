    foreach(Control ctrl in yourform.Controls)
    {
        Textbox = ctrl as TextBox;
        if(txtBox != null)
        {
            if (txtBox.Text == "")
            {
                days.Add("Restday");
            }
            else
            {
                days.Add(txtBox.Text);
            } 
        }
    }
