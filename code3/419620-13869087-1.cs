    void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
    {
        if (navigationContext.NavigationService.Region.Context != null)
        {
                    if (navigationContext.NavigationService.Region.Context is SharedData)
                    {
                        SharedData data = (SharedData)navigationContext.NavigationService.Region.Context;
                        ...
                    }
        }
    }
