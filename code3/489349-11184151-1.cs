        private void Form1_Load(object sender, EventArgs e)
        {
            bkmNameListBox.SelectionMode = SelectionMode.MultiExtended;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var selected in bkmNameListBox.SelectedIndices)
            {
                bkmNameListBox.Items.RemoveAt((int)selected);
            }
        }
