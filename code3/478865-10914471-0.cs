    public partial class PatternLock : UserControl
        {
            bool isMouseDown = false;
    
            private ObservableCollection<ToggleButton> selectedobject = new ObservableCollection<ToggleButton>();
            public PatternLock()
            {
                InitializeComponent();
    
            }
    
            internal ObservableCollection<int> buttons = new ObservableCollection<int>();
    
            private void layoutroot_Checked(object sender, RoutedEventArgs e)
            {
                if (e.OriginalSource is ToggleButton)
                    buttons.Add(Convert.ToInt32(((ToggleButton)e.OriginalSource).Content));
            }
    
            private void layoutroot_Unchecked(object sender, RoutedEventArgs e)
            {
                if (e.OriginalSource is ToggleButton)
                {
                    int i = Convert.ToInt32(((ToggleButton)e.OriginalSource).Content);
                    buttons.Remove(i);
    
                }
            }
    
            internal void ResetPattern()
            {
                if (buttons != null)
                {
                    buttons.Clear();
                    foreach (ToggleButton item in layoutroot.Children)
                    {
                        item.IsChecked = false;
                    }
                }
    
            }
        }
