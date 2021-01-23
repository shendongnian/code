    private void myListViewControl_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        //The projects ListView has been changed
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                MessageBox.Show("An Item Has Been Added To The ListView!");
                break;
            case NotifyCollectionChangedAction.Reset:
                MessageBox.Show("The ListView Has Been Cleared!");
                break;
        }
    }
