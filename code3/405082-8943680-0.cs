    public partial class ItemSelectionUserControl : UserControl 
    {    
        public List<string> AvailableItems     
        {         
            get { return (List<string>)this.GetValue(AvailableItemsProperty); }         
            set { this.SetValue(AvailableItemsProperty, value); }     
        }     
        public static readonly DependencyProperty AvailableItemsProperty = DependencyProperty.Register(
           "AvailableItems", typeof(List<string>), typeof(ItemSelectionUserControl), 
            new FrameworkPropertyMetadata(OnAvailableItemsChanged) {BindsTwoWayByDefault =true});       
        public ItemSelectionUserControl()     
        {         
            InitializeComponent();     
        }   
        public static void OnAvailableItemsChanged(DependencyObject sender, 
               DependencyPropertyChangedEventArgs e)
        {
            // Breakpoint here to see if the new value is being set
            var newValue = e.NewValue;
            Debugger.Break();
        }
    } 
