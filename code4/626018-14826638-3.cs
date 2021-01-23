    if (RadioButton1.Checked == true)
    {    
    
    
        var b = ListBox3.SelectedIndex;
        var a = ListBox3.SelectedValue.ToString();
    
        if (b < 0)
        {
            // no ListBox item selected;
            return;
        }
        
        ListBox4.Items.Add(a);
        ListBox3.Items.RemoveAt(b);
        
        TextBox1.Text = RadioButton1.Text.ToString();
        TextBox2.Text = a;
    }
