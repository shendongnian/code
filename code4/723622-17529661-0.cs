        protected override void OnPreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            DependencyObject source = e.OriginalSource as DependencyObject;
            while (source != null && !(source is System.Windows.Controls.ComboBox)) source = VisualTreeHelper.GetParent(source);
            if (source != null)
            {
                // it was a combo box, don't start drag drop.
            }
            else
            {
                // it wasn't a combo box do drag drop.
            }
            base.OnPreviewMouseLeftButtonDown(e);
        }
