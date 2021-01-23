    void Save()
    {
        SampleDataSource.UpdateGroup(this);
        SampleDataSource.SaveFileAsync();
        this.Frame.Navigate(typeof(GroupedItemsPage), "Message saved");
    }
