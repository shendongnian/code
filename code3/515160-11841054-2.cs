    public static class ListBoxGroup
    {
        public static string GetGroupName(DependencyObject obj)
        {
            return (string)obj.GetValue(GroupNameProperty);
        }
        public static void SetGroupName(DependencyObject obj, string value)
        {
            obj.SetValue(GroupNameProperty, value);
        }
        // Using a DependencyProperty as the backing store for GroupName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.RegisterAttached("GroupName", typeof(string), typeof(ListBoxGroup), new UIPropertyMetadata(null, ListBoxGroupChanged));
        private static Dictionary<string, List<ListBox>> _listBoxes = new Dictionary<string, List<ListBox>>();
        private static void ListBoxGroupChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            string newValue = e.NewValue as string;
            ListBox listBox = obj as ListBox;
            if (newValue == null || listBox == null) return;
            if (_listBoxes.ContainsKey(newValue))
            {
                _listBoxes[newValue].Add(listBox);
            }
            else
            {
                _listBoxes.Add(newValue, new List<ListBox>() { listBox });
            }
            listBox.SelectionChanged += new SelectionChangedEventHandler(listBox_SelectionChanged);
            listBox.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(listBox_KeyUp);
        }
        static void listBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (e.Key == System.Windows.Input.Key.Up && listBox.SelectedIndex == 0)
            {
                //move to previous
                string groupName = GetGroupName(listBox);
                List<ListBox> group = _listBoxes[groupName];
                int senderIndex = group.IndexOf(listBox);
                if (senderIndex != 0)
                {
                    listBox.SelectedItem = null;
                    ListBox beforeSender = group[senderIndex - 1];
                    int index = beforeSender.Items.Count - 1;
                    beforeSender.SelectedIndex = index;
                    var container = beforeSender.ItemContainerGenerator.ContainerFromIndex(index);
                    (container as FrameworkElement).Focus();
                }
            }
            else if (e.Key == System.Windows.Input.Key.Down 
                        && listBox.SelectedIndex == listBox.Items.Count - 1)
            {
                //move to next
                string groupName = GetGroupName(listBox);
                List<ListBox> group = _listBoxes[groupName];
                int senderIndex = group.IndexOf(listBox);
                if (senderIndex != group.Count - 1)
                {
                    listBox.SelectedItem = null;
                    ListBox afterSender = group[senderIndex + 1];
                    afterSender.SelectedIndex = 0;
                    var container = afterSender.ItemContainerGenerator.ContainerFromIndex(0);
                    (container as FrameworkElement).Focus();
                }
            }
            
            
        }
        static void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ListBox listBox = sender as ListBox;
                string groupName = GetGroupName(listBox);
                foreach (var item in _listBoxes[groupName])
                {
                    if (item != listBox)
                    {
                        item.SelectedItem = null;
                    }
                }
            }
            
        }
    }
