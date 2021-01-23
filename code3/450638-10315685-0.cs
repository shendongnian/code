    public class Item : INotifyPropertyChanged
    {
        private int maxValue = 100;
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        void UpdateSum()
        {
            Sum = Col1;// + col2 + col3 etc
        }
    
        decimal _Col1;
        public decimal Col1 
        {                  
            get            
            {                         
                return _Col1;                             
            }                          
            set                       
            {                       
                if (value > maxValue)                                
                {                                
                    Col1 = maxValue; 
                    NotifyPropertyChanged("Col1");
                }
                else
                {
                    _Col1 = value;
                }
                UpdateSum();
                NotifyPropertyChanged("Col1");
            }
        }
    
        public int MaxValueWidth
        {
            get
            {
                var tmp = (int)Math.Log10(maxValue) + 1;
                return tmp;
            }
        }
    
        decimal _Sum;
        public decimal Sum
        {
            get
            {
                return _Sum;
            }
            set
            {
                _Sum = value;
                NotifyPropertyChanged("Sum");
            }
        }
    }
