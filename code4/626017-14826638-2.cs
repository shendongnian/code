    if (RadioButton1.Checked == true)
    {    
                var a = ListBox3.SelectedValue.ToString();
                var b = ListBox3.SelectedIndex;
    
                ListBox4.Items.Add(a);
                ListBox3.Items.RemoveAt(b);
    
                TextBox1.Text = RadioButton1.Text.ToString();
                TextBox2.Text = a;
    }
