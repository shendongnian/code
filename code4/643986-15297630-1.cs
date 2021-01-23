    private void button1_Click(object sender, EventArgs e)
    {
       Control[] aryCtrl = new Control[] { textBox1, textBox2, textBox3, comboBox1, comboBox2, comboBox3 };
       List<string> list = new List<string>();
       foreach (Control ctrl in aryCtrl)
       {
          if (ctrl.Text == "")
          {
             MessageBox.Show("Please enter some text.");
             return;
          }
          else
          {
             list.Add(ctrl.Text);
          }
       }
    }
