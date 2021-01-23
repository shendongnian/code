    private void TabControl_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            MainWindow_VM dc = (MainWindow_VM)this.DataContext;
            
            if (IsUnderTabHeader(e.OriginalSource as DependencyObject))
                //Do what need to be done before switching workspace
                // in my case, switch the focus to a dummy control so the objectContext would save everything, even the currently focused textbox
    
        }
    private bool IsUnderTabHeader(DependencyObject control) 
        {
            if (control is TabItem)
            {
                return true;
            }
            DependencyObject parent = VisualTreeHelper.GetParent(control); 
            if (parent == null)         
                return false; 
            
            return IsUnderTabHeader(parent); 
        }
