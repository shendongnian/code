private void SearchProviderListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string selectedItem = e.AddedItems[0] as string; //I'm not sure, whether it'll be string. Please check the type of objects in the list. But the logic will be the same.
        if(selectedItem == "Google")
        {
            searchProvider = "http://www.google.com/search?q=";
        }
        else if(selectedItem == "Bing")
        {
            searchProvider = "http://www.bing.com/search?q=";
        }
        //Continue the comparison
    }
