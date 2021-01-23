    if (this.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
    {
        this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(
                delegate()
                {
                    Application.Current.Resources["br4"] = new SolidColorBrush(Colors.Green);
                    created.Fill = (SolidColorBrush)Application.Current.Resources["br4"];
                }
                ));
    }
