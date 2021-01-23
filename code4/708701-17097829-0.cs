    if ( App.ConnectClient != null )
        {
            App.ConnectClient.GetCompleted += ConnectClient_GetCompleted;
            App.ConnectClient.BackgroundUploadAsync("me/skydrive",
                                                    new Uri("/" + testFileName, UriKind.Relative),
                                                    OverwriteOption.Overwrite);
        }
