    public MyPage()
    {
        ((MyModel)MyUserControl.DataContext).VisibilityChanged += (sender, args) => {
            VisualStateManager.GoToState(this, "Normal", true);
        };
    }
