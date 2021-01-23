    foreach(var Textbox in this.Controls.OfType<TextBox>())
    {
        if (Textbox.Text == "")
        {
            days.Add("Restday");
        }
        else
        {
            days.Add(Textbox.Text);
        }   
    }
