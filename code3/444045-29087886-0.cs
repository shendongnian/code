            public bool Validate()
        {           
            bool hasErr = false;
          
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(grd); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(grd, i);
                if (child is TextBox)
                {
                    bool pp = BindingOperations.IsDataBound(child, TextBox.TextProperty);
                    if (pp)
                    {
                         ((TextBox)child).Text = ((TextBox)child).Text;
                        hasErr = BindingOperations.GetBindingExpression(child, TextBox.TextProperty).HasError;
                        System.Collections.ObjectModel.ReadOnlyCollection<ValidationError> errors = BindingOperations.GetBindingExpression(child, TextBox.TextProperty).ValidationErrors;
                        if (hasErr)
                        {
                            main.BottomText.Foreground = Brushes.Red;
                            main.BottomText.Text = BindingOperations.GetBinding(child, TextBox.TextProperty).Path.Path.Replace('.', ' ') + ": " + errors[0].ErrorContent.ToString();
                            return false;
                        }
                    }
                }
                if (child is DatePicker)
                {
                    ...                    
                }
            }
            return true;
        }
  
