    private List<Control> AllChildren(DependencyObject parent)
    {
        var _List = new List<Control>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
           var _Child = VisualTreeHelper.GetChild(parent, i);
	       if (_Child is Control)
	       {
			_List.Add(_Child as Control);
	       }
	      _List.AddRange(AllChildren(_Child));
     	}
	    return _List;
     } 
    private T FindControl<T> (DependencyObject parentContainer, string controlName)
    {            
            var childControls = AllChildren(parentContainer);
            var control = childControls.OfType<Control>().Where(x => x.Name.Equals(controlName)).Cast<T>().First();           
            return control;
    }
