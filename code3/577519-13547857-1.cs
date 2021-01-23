    private void tabs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
        switch (e.Action) {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                foreach (DockContainerItem dciItem in e.NewItems) {
                    if (!Parent.Controls.ContainsKey(dciItem.Name))
                        Items.Add(dciItem);
                }
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                Items.Clear();
                break;
        }
    }
