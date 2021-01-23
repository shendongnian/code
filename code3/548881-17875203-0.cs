    Dispatcher.BeginInvoke(() =>
                {
                    UIHelper.ToggleVisibility(Canvas_LocationAR_Trans);
                    UIHelper.ToggleVisibility(Grid_LocARLoadingGrid);
                    **ApplicationBar.IsVisible = true;**
                });
