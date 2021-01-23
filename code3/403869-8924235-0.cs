    foreach (var f in control.GetType().GetFields())
        {
            DependencyProperty dp = f.GetValue(control) as DependencyProperty;
            if (dp != null)
            {
                BindingExpression be = ((FrameworkElement)control).GetBindingExpression(dp);
                if (be != null)
                {
                    // stuff here
                }
            }
         }
