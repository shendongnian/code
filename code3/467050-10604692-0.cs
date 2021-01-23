    public void UserNew() {
        var userViewModel = new UserViewModel(this._windowManager);
        this._windowManager.ShowDialog(userViewModel);
        if (userViewModel.IsCancelled) {
            // Handle cancellation
        } else {
            // Handle other case(s)
        }
    }
