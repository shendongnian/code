    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    
    namespace WpfApplication1
    {
        public class TestViewModel : INotifyPropertyChanged
        {
            public string _name2;
            public string Name2
            {
                get { return "_name2"; }
                set
                { 
                    _name2 = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name2"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
        }
    }
