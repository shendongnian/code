    protected override void OnActivated(EventArgs e)
            {
                base.OnActivated(e);
                if (WindowStyle != WindowStyle.None)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, (DispatcherOperationCallback)delegate(object unused)
                    {
                        WindowStyle = WindowStyle.None;
                        return null;
                    }
                   , null);
                }
            }
