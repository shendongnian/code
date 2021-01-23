    //This goes wherever you create your child view model
    var memberSearchViewModel = new MemberSearchViewModel(); //Or using a service locator, if applicable
    memberSearchViewModel.PropertyChanged += OnMemberSearchPropertyChanged;
    private void OnMemberSearchPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == "SelectedMember")
        {
            //Code to respond to a change in the Member
        }
    }
