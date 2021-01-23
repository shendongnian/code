    public ICommand ExpanderCommand
            {
                get
                {
                    return new RelayCommand(delegate(object param)
                        {
                            var args = (object[])param;
                            var content = (UIElement)args[0];
                            var button = (Button)args[1];
                            content.Visibility = (content.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
                            button.Content = (content.Visibility == Visibility.Visible) ? "-" : "+";
                        });
                }
            }
