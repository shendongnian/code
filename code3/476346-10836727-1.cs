    public class Texto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string name;
        public string Name
        {
            get { return this.name; }
            set 
            { 
                this.name = value; 
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
         public Texto( ) {}
         public Texto(string name) 
         {
            this.name = name;
         }
 
    }
