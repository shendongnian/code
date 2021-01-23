    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    
    namespace StackOverflowWpf2
    {
        public class BorderViewModel : INotifyPropertyChanged
        {
            private bool borderVisible = false;
    
            public bool BorderVisible 
            {
                get
                {
                    return borderVisible;
                }
    
                set
                {
                    borderVisible = value;
                    NotifyPropertyChanged("BorderVisible");
                }
            }
    
            private void NotifyPropertyChanged(string info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
