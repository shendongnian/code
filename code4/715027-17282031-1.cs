    IList<DataGridViewBand> typedCollection = collection
                                              .Cast<DataGridViewBand>()
                                              .ToList();
    
    private void SelectNew(IList<DataGridViewBand> collection, int index)
    {
      ClearSelection();
      collection[index].Selected = true;
    }
    
    typedCollection.SelectNew(1);
