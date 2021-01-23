    public sealed partial class MyUserControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyUserControl() { this.InitializeComponent(); }
        // text property
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyUserControl), new PropertyMetadata(0, (s, e) =>
            {
                var _MyImageControl = s as MyUserControl;
                _MyImageControl.RaisePropertyChanged(TextProperty.ToString());
            }));
        void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
