      private void button_Click(object sender, EventArgs e)
            {
    
                Button button = sender as Button;
                if (button == null) return;
                String name = button.Text;// Tag, name etc
    
    
                dailogueOpen(name);
            }
      
    
         private void dailogueOpen(String btnName)
            {
                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please Select a form");
                }
                else
                {
                    var selectedItem = (FormItems)listBox1.SelectedItem;
                    var form2result = new Form2(myDataSet, selectedItem);
                    var resulOfForm2 = form2result.ShowDialog();
        
                    if (resulOfForm2 == DialogResult.OK)
                    { 
                       SetTxt(btnName,form2result.getValue());
                    }
                }
        }
    
     
    
          private void SetTxt(string btnName, string value)
                {
                    int lenght = "Button".Length;
                    string index = btnName.Substring(lenght); //remove Button
                    TextBox t = (TextBox)this.Controls.Find("textBox" + index, true)[0];
        
                    if (t != null)
                        t.Text = value;
                }
