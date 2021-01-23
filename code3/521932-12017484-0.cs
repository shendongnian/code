    listItems = new List<string>();
    foreach (ListViewItem item in objectListViewDisks.Items)
                {
                    //If you want to add tag to list then you can use dictionary like Dictionary<string, object) listItems; and then add items as listItems.Add(item.Text, item.Tag); It only works if text is unique.
                    listItems.Add(item.Text);
                }
    bgw1.RunWorkerAsync();
