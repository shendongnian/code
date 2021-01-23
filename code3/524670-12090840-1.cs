    private void CloseLocalPopup(object args)
        {
            var act = new Action(() =>
            {
                localPop.IsOpen = false;
            });
            Dispatcher.BeginInvoke(act, null);
        }
