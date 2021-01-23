    private void button1_Click(object sender, EventArgs e)
    {
       Control[] aryCtrl = new Control[] { textBox1, textBox2, textBox3, dropdownlist1, dropdownlist2, dropdownlist3 };
       List<string> list = new List<string>();
       foreach (Control ctrl in aryCtrl)
       {
          list.Add(textbox1.Text);
          list.Add(textbox2.Text);
          list.Add(textbox3.Text);
          list.Add(dropdownlist1.Text);
          list.Add(dropdownlist2.Text);
          list.Add(dropdownlist3.Text);
       }
    }
    Control[] aryCtrl = new Control[] { textBox1, textBox2, textBox3, comboBox1, comboBox2, comboBox3 };
