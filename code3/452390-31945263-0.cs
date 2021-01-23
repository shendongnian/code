            public static readonly DependencyProperty ShowIconProperty = DependencyProperty.RegisterAttached(
                                "ShowIcon",
                                typeof(bool),
                                typeof(WindowsManager),
                                new FrameworkPropertyMetadata(true, new PropertyChangedCallback((d, e) =>
                                    {
                                        if (!DesignTimeHelper.GetIsInDesignMode())
                                            RemoveIcon((Window)d);
                                    }
                                    )));
