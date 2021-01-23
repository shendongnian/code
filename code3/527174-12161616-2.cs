    using System.ComponentModel;
    
    namespace WpfApplication16
    {
        public class MySuperDataContextClass : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private bool _mySuperCheckBoxIsChecked;
            private float _mySuperFloatValue;
    
            public bool MySuperCheckBoxIsChecked
            {
                get { return _mySuperCheckBoxIsChecked; }
    
                set 
                {
                    _mySuperCheckBoxIsChecked = value;
    
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this,
                         new PropertyChangedEventArgs("MySuperCheckBoxIsChecked"));
                    }
                }
            }
    
            public float MySuperFloatValue
            {
                get { return _mySuperFloatValue; }
                
                set 
                { 
                    _mySuperFloatValue = value;
                    
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this,
                         new PropertyChangedEventArgs("MySuperFloatValue"));
                    }
                }
            }
        }
    }
