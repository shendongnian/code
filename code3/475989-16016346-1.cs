             void detectScreenType()
        {
            double dpi = DisplayProperties.LogicalDpi;
            var bounds = Window.Current.Bounds;
            double h;
            switch (ApplicationView.Value)
            {
                case ApplicationViewState.Filled:
                    h = bounds.Height;
                    break;
                case ApplicationViewState.FullScreenLandscape:
                    h = bounds.Height;
                    break;
                case ApplicationViewState.Snapped:
                    h = bounds.Height;
                    break;
                case ApplicationViewState.FullScreenPortrait:
                    h = bounds.Width;
                    break;
                default:
                    return;
            }
            double inches = h / dpi ;
            string screenType = "Slate";
            if (inches < 10)
            {
                screenType = "Slate";
            } else if (inches < 14) {
                screenType = "WorkHorsePC";
            }
            else 
            {
                screenType = "FamilyHub";
            }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["screenType"] = screenType;
        }
 
