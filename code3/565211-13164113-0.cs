        Public Shared RadiusSizeProperty As DependencyProperty = DependencyProperty.Register("RadiusSize",
                                                                 GetType(Double),
                                                                 GetType(Radius),
                                                                 New PropertyMetadata(0.5, Sub(s, e)
                                                                                               Dim p As DependencyPropertyChangedEventArgs = e
                                                                                               Dim o As DependencyObject = s
                                                                                               o.SetValue(HeightProperty, p.NewValue)
                                                                                               o.SetValue(WidthProperty, p.NewValue)
                                                                                           End Sub))
