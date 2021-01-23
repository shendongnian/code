    public void StartGame()
    {
        base.NavigationService.Navigated += NavigationServiceOnNavigated;
        base.NavigationService.NavigateToViewModel<GameViewModel>(Players);
        base.NavigationService.Navigated -= NavigationServiceOnNavigated;
    }
