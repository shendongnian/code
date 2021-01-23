            private void Window_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                var control = FindVisualParent<MyContainedControl1>(e.OriginalSource as DependencyObject);
                if (control != null)
                {
                    //magic happens here
                }
            }
    
            public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
            {
                var parent = VisualTreeHelper.GetParent(child);
                if (parent == null) 
                    return null;
                T pT = parent as T;
                return pT != null ? pT : FindVisualParent<T>(parent);
            }
