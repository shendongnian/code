      private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            foreach (object selectedItem in listBox1.SelectedItems)
            {
               message.Append(selectedItem.ToString() + Environment.NewLine);
            }
            Form2 objForm2 = new Form2();
            objForm2.message = message.ToString();
            objForm2.ShowDialog();
