    void GeneratePreview<T>(int itemsPerPage)
    {
        var printAbleListView = (ListView)printObject.FindName("printAbleListView");
        var allItems = (ObservableCollection<T>)printAbleListView.DataContext;
        
        // Add the page to the page preview collection
        for (int i = 0; i <= (allItems.Count()/itemsPerPage); i++)
        {
          printAbleListView.DataContext =
                  allItems.Skip(itemsPerPage * i).Take(itemsPerPage);
          document.SetPreviewPage((i + 1), printObject);
        }
    }
