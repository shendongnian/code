    private void Sync_lists(ListView sender)
        {
            if ((newFilesList.Items.Count > 0) && (oldFilesList.Items.Count > 0))
            {
                int cur_top_index = sender.TopItem.Index;
                ListViewItem future_top_item;
                if (sender == oldFilesList)
                {
                    future_top_item = newFilesList.Items[cur_top_index];
                    newFilesList.TopItem = future_top_item;
                }
                else
                {
                    future_top_item = oldFilesList.Items[cur_top_index];
                    oldFilesList.TopItem = future_top_item;
                }
            }
        }
