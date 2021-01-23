        public class TabItemHolder : DependencyObject, INotifyPropertyChanged
        {
            public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(String), typeof(TabItemHolder), new UIPropertyMetadata());
            public String Header
            {
                get { return (String)GetValue(HeaderProperty); }
                set
                {
                    SetValue(HeaderProperty, value);
                    NotifyPropertyChanged("Header");
                }
            }
    
            public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(String), typeof(TabItemHolder), new UIPropertyMetadata());
            public String Text
            {
                get { return (String)GetValue(TextProperty); }
                set
                {
                    SetValue(TextProperty, value);
                    NotifyPropertyChanged("Text");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(String PropertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
