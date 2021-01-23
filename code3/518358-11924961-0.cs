    public partial class MainWindow : Window, INotifyPropertyChanged
    { 
        private User selectedUser;
    
        public User SelectedUser 
        {
           get 
           {
               return selectedUser;
           }
           set
           {
               selectedUser = value;
               NotifyPropertyChanged("SelectedUser");
           }
        }
     
        public MainWindow() 
        { 
            InitializeComponent(); 
            ReloadContents(); 
     
            // Now the source is the current object (Window), which implements
            // INotifyPropertyChanged and can tell to WPF infrastracture when 
            // SelectedUser property will change value
            Binding b = new Binding(); 
            b.Source = this; 
            b.Path = new PropertyPath("SelectedUser.uFirstName"); 
            this.txtFirstName.SetBinding(TextBox.TextProperty, b); 
       } 
    
       public event PropertyChangedEventHandler PropertyChanged;
       
       private void NotifyPropertyChanged(string info)
       {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
       }
    }
