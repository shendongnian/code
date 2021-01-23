            control.OK_BTN.Click += (s, args) =>
            {
                popup.IsOpen = false;
                this.IsEnabled = true;
                Dispatcher.BeginInvoke(() =>
                    {
                        MessageBoxResult result = MessageBox.Show("Do you want to reset the settings ?", "Settings", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            changeSettings();
                        }
                    });
            };
