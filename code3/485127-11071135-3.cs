    protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        switch(e.Key)
        {
            case Key.Up:
            case Key.Down:
               MyViewModel.IsUserNavigating = true;
               break;
        }
    }
