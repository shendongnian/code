        public class YourClassThatHasTheInputValuePropertyInIt: INotifyPropertyChanged
        {
                public event PropertyChangedEventHandler PropertyChanged;
                private void NotifyPropertyChanged(String propertyName)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
    
                public string InputValue
                {
                    get { return (string)GetValue(InputValueProperty); }
                    set { SetValue(InputValueProperty, value);
                          NotifyPropertyChanged("InputValue"); }
         }
        }
