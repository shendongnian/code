    private void OnMemberSearchPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == "SelectedMember")
        {
            //Code to respond to a change in the Member
            //Unsubscribe so the view model can be garbage collected
            _memberSearchViewModel.PropertyChanged -= OnMemberSearchPropertyChanged;
            _memberSearchViewModel = null;
        }
    }
