    var child = new Child();
                SetRelative(child, currentPosition / ActualWidth);
                var multiBinding = new MultiBinding { Converter = new RelativePositionConverter() };
                multiBinding.Bindings.Add(new Binding { Source = child, Path = new PropertyPath(RelativeProperty) });
                multiBinding.Bindings.Add(new Binding { Source = canvas, Path = new PropertyPath(ActualWidthProperty) });
                BindingOperations.SetBinding(child, LeftProperty, multiBinding);
                Children.Add(child);
