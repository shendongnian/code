            BindingScope.AddChildResolver(
                type => type == typeof(System.Windows.Controls.ContentPresenter),
                control =>
                {
                    var result = new List<DependencyObject>();
                    var typedControl = control as System.Windows.Controls.ContentPresenter;
                    if (typedControl != null)
                    {
                        if (typedControl.Content is DependencyObject)
                        {
                            result.Add(typedControl.Content as DependencyObject);
                        }
                    }
                    return result;
                });
