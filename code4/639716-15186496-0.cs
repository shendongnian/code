    void DoSomething<T>()
    {
        var printAbleListView = (ListView) printObject.FindName("printAbleListView");
        ObservableCollection<T> allItems = (ObservableCollection<T>) printAbleListView.DataContext;
        
        // Add the page to the page preview collection
        for (int i = 0; i <= (allItems.Count()/30); i++)
        {
          printAbleListView.DataContext = allItems.Skip(30 * i).Take(30);
          document.SetPreviewPage((i + 1), printObject);
        }
    }
