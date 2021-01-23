    if (System.Windows.Application.Current.Dispatcher.CheckAccess())
            {
                Messages.Add(message);
            }
            else
            {
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() => Messages.Add(message)));
            }
