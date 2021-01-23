    private void OnSelectAllClick(object sender, EventArgs e)
        {
            LongListMultiSelectorName.SelectedItems.Clear();
            foreach (var item in LongListMultiSelectorName.ItemsSource)
            {
                LongListMultiSelectorName.SelectedItems.Add(item);
            }
        }
