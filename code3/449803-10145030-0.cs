        private void OnValidationError(Object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is DependencyObject)
            {
                DependencyObject instance = e.OriginalSource as DependencyObject;
                if (Validation.GetHasError(instance))
                {
                    System.Collections.ObjectModel.ReadOnlyObservableCollection<ValidationError> errors = Validation.GetErrors(instance);
                    // todo build message from errors and display
                }
            }
        }
