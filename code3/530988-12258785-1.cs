    protected void Button_Click(object sender, EventArgs e)
    {
        int q1 = Convert.ToInt16(TextBox1.Text);
        
        string t1 = DropDownList1.SelectedItem.ToString().Trim();
        int start = 1;
        string checkBoxValue = string.Concat(t1, start);
        while (CheckBoxList1.Items.Cointains(new ListItem(checkBoxValue)))
        {
            start++;
            checkBoxValue = string.Concat(t1, start);
        }
        
        for (int i = start; i <= start + q1 - 1; i++)
        {
            CheckBoxList1.Items.Add(string.Concat(t1, i));
        }
    
        TextBox1.Text = "";
    }
