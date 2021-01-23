    class ListBoxEx : ListBox
    {
        // Use the 'new' keyword so that we 'hide' the base property.
        // This means that binding will go to this version of SelectedItems
        // rather than whatever the base class uses. To reach the base 'SelectedItems' property
        // We just need to use base.SelectedItems instead of this.SelectedItems
        // Note that we register as an observable collection.
        new DependencyProperty SelectedItemsProperty = 
            DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<String>), typeof(ListBoxEx));
        // Accessor. Again, note the 'new'.
        new public ObservableCollection<String> SelectedItems
        {
            get { return (ObservableCollection<String>) GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            // Guard against ViewModel being null
            if (this.SelectedItems != null)
            {
                // Clear the list
                this.SelectedItems.Clear();
                // (1) On selection changed. Get the new base.SelectedItems
                // (2) Cast each item to a String ("Make a string collection")
                // (3) Cast to list, and use foreach to add each item to 
                // this.SelectedItems (note this is different from the original base.SelectedItems)
                base.SelectedItems.Cast<String>()
                    .ToList()
                    .ForEach(this.SelectedItems.Add);
            }
        }
    }
