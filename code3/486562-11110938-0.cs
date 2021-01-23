    public void ScenarioList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.AddedItems[0] as ListBoxItem;
        var selectedText = ((TextBlock)item.Content).Text;
    }
