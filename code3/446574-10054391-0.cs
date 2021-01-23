    public class MyUserControl : UserControl, INotifyPropertyChanged
    {
        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged; 
        protected void OnPropertyChanged(string propertyName) 
        { 
            if (PropertyChanged != null) 
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
            } 
        } 
        //The XAML binding uses this
        public static readonly DependencyProperty CaptionProperty = 
             DependencyProperty.Register("Caption", typeof(string), typeof(MyUserControl), 
             new PropertyMetadata(string.Empty, OnCaptionPropertyChanged));
        
        //Your code-behind uses this
        public string Caption 
        {  
            get { return GetValue(CaptionProperty).ToString(); }  
            set 
            {
                SetValue(CaptionProperty, value);
                OnPropertyChanged("Caption");
            } 
        }
