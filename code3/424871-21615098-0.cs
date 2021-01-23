     private void button1_Click(object sender, EventArgs e)
     {
         string[] itemsToRemove = new string[listBox1.SelectedItems.Count];
         listBox1.SelectedItems.CopyTo(itemsToRemove, 0);
         foreach (string item in itemsToRemove)
         {
             listBox1.Items.Remove(item);
         }
     }
