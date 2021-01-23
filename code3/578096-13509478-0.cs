    string[] longMsg = str.Split('*'); //Message contains * character as delimiter
    
    
        for (int i = 0; i < longMsg.Length; i++)
        {
            CheckBox cb = new CheckBox();
    
            cb.Text = longMsg[i];
            Form.Controls.Add(cb);
            Form.Controls.Add(new LiteralControl("<br>"));
    
        }
