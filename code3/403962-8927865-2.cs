        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source == wizardTabs && e.RemovedItems.Count != 0 && e.AddedItems.Count != 0)
            {
                TabItem fromItem = e.RemovedItems[0] as TabItem;
                TabItem toItem = e.AddedItems[0] as TabItem;
                if (fromItem.Name == "lastTab" && toItem.Name == "firstTab")
                {
                    e.Handled = true;
                    wizardTabs.SelectedItem = fromItem;
                    fromItem.Focus();
                }
            }
        }
