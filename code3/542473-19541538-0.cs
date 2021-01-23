        public List<string> GetItems()
            {
            var items = new List<string>();
            foreach (Ranorex.ListItem item in ranorexComboBox.Items)
                {
                items.Add(item.Text);
                }
            return items;
            }
