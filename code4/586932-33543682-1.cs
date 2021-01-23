           public string GetListItems()
            {
                System.Collections.Generic.List<string> items = new System.Collections.Generic.List<string>();
            foreach (ListItem item in lstfunction.Items)
            {
                if (item.Selected)
                {
                    items.Add(item.Value);
                }
            }
            return String.Join(", ", items.ToArray());
        }
