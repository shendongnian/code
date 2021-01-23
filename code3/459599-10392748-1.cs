    using System.Windows;
    using System.ComponentModel;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MyWindow.xaml
        /// </summary>
        public partial class MyWindow : Window, INotifyPropertyChanged
        {
            public MyWindow()
            {
                InitializeComponent();
    
                DataContext = this;  // Sets context of binding to the class 
            }
    
    
            // Property for binding
            private string _mylabelvalue;
            public string MyLabelValue
            {
                get { return _mylabelvalue; }
                set 
                { 
                    _mylabelvalue = value;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MyLabelValue"));
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
