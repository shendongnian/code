    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            private double _value1;
            public double Value1
            {
                get { return _value1; }
                set
                {
                    if(value != _value1)
                    {
                        _value1 = value;
                        DoMyCalculations(_value1, _value2, _value3);
                        NotifyPropertChanged("Value1");
                    }
                }
            }
            private double _value2;
            public double Value2
            {
                get { return _value2; }
                set
                {
                    if (value != _value2)
                    {
                        _value2 = value;
                        DoMyCalculations(_value1, _value2, _value3);
                        NotifyPropertChanged("Value2");
                    }
                }
            }
            private double _value3;
            public double Value3
            {
                get { return _value3; }
                set
                {
                    if (value != _value3)
                    {
                        _value3 = value;
                        DoMyCalculations(_value1, _value2, _value3);
                        NotifyPropertChanged("Value3");
                    }
                }
            }
            private bool isCalculating = false;
            private void DoMyCalculations(double value1, double value2, double value3)
            {
                if (isCalculating)
                    return;
                isCalculating = true;
                
                // Perform logic to reset here
    
    
                isCalculating = false;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Notify of Property Changed event
            /// </summary>
            /// <param name="propertyName"></param>
            public void NotifyPropertChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
