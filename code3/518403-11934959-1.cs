    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
    
        public ICommand SelectedItemDoubleClickedCommand
        {
            get { return (ICommand)GetValue(SelectedItemDoubleClickedCommandProperty); }
            set { SetValue(SelectedItemDoubleClickedCommandProperty, value); }
        }
    
        public static readonly DependencyProperty SelectedItemDoubleClickedCommandProperty = DependencyProperty.Register(
            "SelectedItemDoubleClickedCommand", typeof(ICommand), 
            typeof(UserControl1), 
            new UIPropertyMetadata(null));
    
        public static ICommand GetSelectedItemDoubleClickedCommandAttached(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectedItemDoubleClickedCommandAttachedProperty);
        }
    
        public static void SetSelectedItemDoubleClickedCommandAttached(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectedItemDoubleClickedCommandAttachedProperty, value);
        }
    
        public static readonly DependencyProperty SelectedItemDoubleClickedCommandAttachedProperty = DependencyProperty.RegisterAttached(
            "SelectedItemDoubleClickedCommandAttached", 
            typeof(ICommand), typeof(UserControl1), 
            new UIPropertyMetadata(null, SelectedItemDoubleClickedCommandAttachedChanged));
    
        private static void SelectedItemDoubleClickedCommandAttachedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = d as TreeViewItem;
            if (item != null)
            {
                if (e.NewValue != null)
                {
                    var binding = new MouseBinding((ICommand)e.NewValue, new MouseGesture(MouseAction.LeftDoubleClick));
                    
                    BindingOperations.SetBinding(binding, InputBinding.CommandParameterProperty, new Binding("SelectedItem")
                    {
                        RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(TreeView), 1)
                    });
    
                    item.InputBindings.Add(binding);
                }
            }
        }
    }
