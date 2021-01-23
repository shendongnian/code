    CustomMessageBox.Dismissed += (dismissSender, dismissedEvent) =>
    {
        switch (dismissedEvent.Result)
        {
            case CustomMessageBoxResult.LeftButton:
                PlaceCall(clickedFavorite.Name, clickedFavorite.PhoneNo);
                break;
            case CustomMessageBoxResult.RightButton:
                Dispatcher.BeginInvoke(new Action(() => SendText(clickedFavorite.PhoneNo)));
                break;
        }
    };
