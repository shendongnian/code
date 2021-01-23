        private void Form1_Load(object sender, EventArgs e)
        {
            bkmNameListBox.SelectionMode = SelectionMode.MultiExtended;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            while (bkmNameListBox.SelectedItems.Count > 0)
            {
                Removedatabasefiled(bkmNameListBox.SelectedItems[0]);
                bkmNameListBox.Items.Remove(bkmNameListBox.SelectedItems[0]);
            }
        }
