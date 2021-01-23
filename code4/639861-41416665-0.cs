     private List<Control> AllChildren(DependencyObject parent, Func<DependencyObject, bool> query,   List<Control> _List = null ) 
        {
            if (_List == null)
                 _List = new List<Control>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control && query(_Child))
                {
                    _List.Add(_Child as Control);
                }
                AllChildren(_Child, query, _List);
            }
            return _List;
        }
