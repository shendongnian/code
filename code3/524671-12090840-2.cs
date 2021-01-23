    private void ShowNotifyBaloon(NotifyBaloonViewModel vm)
        {
            var act = new Action(() =>
            {
                localPop.IsOpen = true;
                localPopTimer.Change(4000, Timeout.Infinite);
            });
            Dispatcher.BeginInvoke(act, null);
        }
