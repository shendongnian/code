    void GeneratePreview(int itemsPerPage)
    {
        var printAbleListView = (ListView)printObject.FindName("printAbleListView");
        var allItems = (ICollection)printAbleListView.DataContext;
        
        var slice = new List<object>(itemsPerPage); // cannot use ArrayList for Win8 apps
        var pageNo = 1;
        foreach (var item in allItems)
        {            
            slice.Add(item);
            if (slice.Count % itemsPerPage == 0)
            {
                // flush
                printAbleListView.DataContext = slice;
                document.SetPreviewPage(pageNo, printObject);
                // and restart
                pageNo++;
                slice.Clear();
            }
        }
        if (slice.Count != 0) // flush the rest
        {
            printAbleListView.DataContext = slice;
            document.SetPreviewPage(pageNo, printObject);
        }
        // clean up
        printAbleListView.DataContext = null;
    }
