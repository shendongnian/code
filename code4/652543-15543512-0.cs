    public class ViewModelThatHostsTheListViewModel
    {
        // All these properties should have property changed notification, I'm just leaving it out for the example
        public PropertyChangedBase SelectedViewModel { get; set; } 
        public object SelectedItem { get; set; }
        // Dictionary to hold last selected item for each VM - you might actually want to track this in the child VMs but this is just one way to do it
        public Dictionary<PropertyChangedBase, object> _lastSelectedItem = new Dictionary..etc()
        // Keep the dictionary of last selected item up to date when the selected item changes
        public override void NotifyOfPropertyChange(string propertyName)
        {
            if(propertyName == "SelectedItem")
            {
                if(_lastSelectedItem.ContainsKey(SelectedViewModel))
                    _lastSelectedItem[SelectedViewModel] = SelectedItem;
                else
                    _lastSelectedItem.Add(SelectedViewModel, SelectedItem);
            }
        }
    }
