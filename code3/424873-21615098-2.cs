     private void button1_Click(object sender, EventArgs e)
     {
         object[] itemsToRemove = new object[listBox1.SelectedItems.Count];
         listBox1.SelectedItems.CopyTo(itemsToRemove, 0);
         foreach (object item in itemsToRemove)
         {
             listBox1.Items.Remove(item);
             listBox2.Items.Add(item);
         }
     }
