    public class VideoFile : INotifyPropertyChanged {
    
        string m_FilePath;
        public string FilePath 
        { 
           get { return m_FilePath; } 
           protected set
           {
              if(value != m_FilePath)
              {
                 m_FilePath = value;
                 RaisePropertyChanged(() => this.FilePath);
              }
           }
        }
        public uint ID { get; protected set; }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged<T>(Expression<Func<T>> _PropertyExpression)
        {
            RaisePropertyChanged(PropertySupport.ExtractPropertyName(_PropertyExpression));
        }
    
        protected void RaisePropertyChanged(String _Prop)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(_Prop));
            }
        }
    
        #endregion
    }
