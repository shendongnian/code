    ConventionManager.AddElementConvention<ItemsControl>(ItemsControl.ItemsSourceProperty, "DataContext", "Loaded")
                 .ApplyBinding = (viewModelType, path, property, element, convention) => {
                                     ConventionManager.SetBinding(viewModelType, path, property, element, convention, ItemsControl.ItemsSourceProperty);
                                     ConventionManager.ApplyItemTemplate((ItemsControl) element, property);
                                     return true;
                                 };
