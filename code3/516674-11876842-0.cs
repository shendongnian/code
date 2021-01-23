        private void UpdateToString(ListBox listBox)
        {
            int count = listBox.Items.Count;
            listBox.SuspendLayout();
            for (int i = 0; i < count; i++)
            {
                listBox.Items[i] = listBox.Items[i];
            }
            listBox.ResumeLayout();
        }
