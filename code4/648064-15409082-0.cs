    public interface IClass : INotifyPropertyChanged 
        {
            string Name { get; set;}
        }
    
    public class MyClass: IClass
        {
            private string name;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
    
            public MyClass(string name)
            {
                this.Name = name;
            }
    
            private void NotifyPropertyChanged(string caller = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
                }
            }
