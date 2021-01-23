      Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    if (this.Frame != null)
                    {
                        Frame.Navigate(typeof(NetworkDisconection));
                    }
                });
