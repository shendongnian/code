            public static Boolean Revalidate<T>(this Window depObj) where T : DependencyObject
        {
            bool isValid = true;
            foreach (T obj in FindVisualChildren<T>(depObj))
            {
                var name = typeof(T).Name.ToLower();
                BindingExpression exp = null;
                switch (name)
                {
                    case "textbox":
                        var tb = obj as TextBox;
                        exp = tb.GetBindingExpression(TextBox.TextProperty);
                        exp.UpdateSource();
                        if (Validation.GetHasError(tb))
                            isValid = false;  
                        break;           
                }                             
            }
            return isValid;
        }
