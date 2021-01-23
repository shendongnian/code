        ApplicationViewState viewState = ApplicationView.Value;
        if (viewState == ApplicationViewState.Filled)
        {
            System.Diagnostics.Debug.WriteLine("viewState is Filled");
        }
        else if (viewState == ApplicationViewState.FullScreenLandscape)
        {
            System.Diagnostics.Debug.WriteLine("viewState is FullScreenLandscape");
        }
        else if (viewState == ApplicationViewState.Snapped)
        {
            System.Diagnostics.Debug.WriteLine("viewState is Snapped");
        }
        else if (viewState == ApplicationViewState.FullScreenPortrait)
        {
            System.Diagnostics.Debug.WriteLine("viewState is FullScreenPortrait");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("viewState is something unexpected");
        }
