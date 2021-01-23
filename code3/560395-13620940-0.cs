    //Use the below code to Expand the particular group based on the key
    void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (Group group in this.AssociatedObject.Model.View.Groups)
        {
            if (group.Key.Equals(1))
                this.AssociatedObject.Model.Table.ExpandGroup(group);
        }
    }
