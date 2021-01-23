    public sealed partial class MyUserControl : UserControl, INotifyPropertyChanged
    {
        public MyUserControl()
        {
            this.InitializeComponent();
        }
        // text property
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValueDp(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyUserControl), null);
        // bindable
        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value,
            [System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            SetValue(property, value);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
