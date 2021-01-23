        {
            while(ShowListBox.Items.Count != 0)
            {
                for(int i = 0; i < ShowListBox.Items.Count; i++)
                {
                    ShowListBox.Items.Remove(ShowListBox.Items[i].ToString());
                }
                while (ShowListBox.Items.Count > 0)
                {
                    ShowListBox.Items.RemoveAt(0);
                }
            }
        }
