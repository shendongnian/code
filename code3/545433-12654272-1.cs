    public class RowData : INotifyPropertyChanged
    {
        private string box1;
        public string Box1 
        {
            get { return box1; }
            set
            {
                if(box1 == value) return;
                box1= value;
                NotifyPropertyChanged("Box1 ");
            }
        }
     //repete the same to Box2 and Box3
     public event PropertyChangedEventHandler PropertyChanged;
     private void NotifyPropertyChanged(String propertyName)
     {
         if (PropertyChanged != null)
         {
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
     }
     }
