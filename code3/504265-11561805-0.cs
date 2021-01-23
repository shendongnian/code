            List<string> listItems = new List<string>();
            foreach (TabItem item in tabControl1.Items)
            {
                if (item.IsEnabled)
                    listItems.Add(item.Header.ToString());
            }
