    public static class SingleSelectionGroup
    {
        private static readonly Dictionary<string, ICollection<Selector>> _selectors =
            new Dictionary<string, ICollection<Selector>>();
    
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.RegisterAttached("GroupName", typeof (string), typeof (Selector),
                                                new UIPropertyMetadata(OnGroupNameChanged));
    
        public static string GetGroupname(Selector selector)
        {
            return (string) selector.GetValue(GroupNameProperty);
        }
    
        public static void SetGroupName(Selector selector, string value)
        {
            selector.SetValue(GroupNameProperty, value);
        }
    
        private static void OnGroupNameChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
                RemoveSelector((Selector) dependencyObject, (string) e.OldValue);
            if (e.NewValue != null)
                AddSelector((Selector) dependencyObject, (string) e.NewValue);
        }
        private static void RemoveSelector(Selector selector, string groupName)
        {
            _selectors[groupName].Remove(selector);
            selector.SelectionChanged -= SelectorOnSelectionChanged;
        }
    
        private static void AddSelector(Selector selector, string groupName)
        {
            if (_selectors.ContainsKey(groupName))
            {
                _selectors[groupName].Add(selector);
            }
            else
            {
                var selectorCollection = new Collection<Selector> { selector };
                _selectors.Add(groupName, selectorCollection);
            }
    
            selector.SelectionChanged += SelectorOnSelectionChanged;
        }
    
        private static void SelectorOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
                
            var groupName = (string) ((Selector) sender).GetValue(GroupNameProperty);
            foreach(var selector in _selectors[groupName])
            {
                if (selector.Equals(sender))
                    continue;
                selector.SelectedIndex = -1;
            }
        }
    }
