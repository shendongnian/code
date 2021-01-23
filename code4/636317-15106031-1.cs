    private void button1_Click(object sender, EventArgs e)
     {
         StringBuilder message = new StringBuilder();
    
         foreach (object selectedItem in listBox1.SelectedItems)
         {
              message.Append(selectedItem.ToString() + Environment.NewLine);
         }
    
         var form = new Form2();
         form.SetRichTextboxText(message.ToString());
         form.Show(this);
    }
