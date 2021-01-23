    private void CxmlCollectionSource_StateChanged(object sender, CxmlCollectionStateChangedEventArgs e)
    {
        // TODO: check other states
        switch (e.NewState)
        {
            case CxmlCollectionState.Loaded:
                {
                    var collection = sender as CxmlCollectionSource;
                    Debug.Assert(collection != null, "collection != null");
                    // TODO: don't add/remove, replace the entire list after diffing
                    if (!this.pivotProperties.Any())
                    {
                        // TODO: diffing algorithm for properties, minimal changes
                        foreach (var pivotViewerProperty in collection.ItemProperties)
                        {
                            this.pivotProperties.Add(pivotViewerProperty);
                        }
                    }
                    this.pivotViewerItems.KeepIntersection(collection);
                    break;
                }
        }
    }
