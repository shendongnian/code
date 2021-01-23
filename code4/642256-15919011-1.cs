    private static void NavigationServiceOnNavigated(object sender, NavigationEventArgs args)
    {
        FrameworkElement view;
        GameViewModel gameViewModel;
        if ((view = args.Content as FrameworkElement) == null || 
            (gameViewModel = view.DataContext as GameViewModel) == null) return;
        gameViewModel.InitializeScoreBoard(args.Parameter as IEnumerable<Player>);
    }
