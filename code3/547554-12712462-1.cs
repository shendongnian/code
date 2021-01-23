       private void selectItemByKey(int key)
       {
            foreach (WorkItem item in comboBox.Items)
            {
                if (item.Key.Equals(key))
                    comboBox.SelectedItem = item;
            }
       }`
