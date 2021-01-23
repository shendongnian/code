    public static object GetSelectedTreeItem(DependencyObject obj)
    {
    	return (object)obj.GetValue(SelectedTreeItemProperty);
    }
    public static void SetSelectedTreeItem(DependencyObject obj, object value)
    {
    	obj.SetValue(SelectedTreeItemProperty, value);
    }
    
    // Using a DependencyProperty as the backing store for SelectedTreeItem.  This enables     animation, styling, binding, etc...
    public static readonly DependencyProperty SelectedTreeItemProperty =
    	DependencyProperty.RegisterAttached("SelectedTreeItem", typeof(object), typeof(YourVMClass), new PropertyMetadata(null, OnSelectedItemChange));
    public static void OnSelectedItemChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    	//do your stuff here eg.
    	YourVMClass vm = d as YourVMClass;
    	dynamic selectedItem = e.NewValue;
    	vm.categoryName = selectedItem.Name;
    	vm.categoryID = selectedItem.Tag.ToString();
    	vm.categoryChosen = true;
    }
