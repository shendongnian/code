         var messageBox = new CustomMessageBox()
            {
                Name = "FilterCustomMessageBox", // added this
                ContentTemplate = (DataTemplate)view.Resources["PivotContentTemplate"],
                DataContext = view.DataContext,
                LeftButtonContent = "filter",
                RightButtonContent = "cancel",
                IsFullScreen = true
            };
