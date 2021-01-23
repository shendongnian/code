    public class MyClass : DependencyObject, INotifyPropertyChanged
    {
    
        public MyClass ()
        {
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public bool State
        {
            get { return (bool)this.GetValue(StateProperty); }
            set { this.SetValue(StateProperty, value); } 
        }
    
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register(
                "State", 
                typeof(bool), 
                typeof(MyClass),
                new PropertyMetadata(
                    false, // Default value
                    new PropertyChangedCallback(OnDependencyPropertyChange)));
    
        private static void OnDependencyPropertyChange(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(d, 
                    new PropertyChangedEventArgs(e.Property.Name);
            }
        }
    }
