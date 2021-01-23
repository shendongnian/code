    public class ModelClass : INotifyPropertyChanged
            {
                private string destinationCity;
                public string SourceCity { get; set; }
                
                public ModelClass()
                {
                    PropertyChanged += CustomAttribute.ThrowIfNotEquals;
                }
    
                [Custom("SourceCity", ErrorMessage = "the source and destination should not be equal")]
                public string DestinationCity
                {
                    get
                    {
                        return this.destinationCity;
                    }
    
                    set
                    {
                        if (value != this.destinationCity)
                        {
                            this.destinationCity = value;
                            NotifyPropertyChanged("DestinationCity");
                        }
                    }
                }
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected virtual void NotifyPropertyChanged(string info)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(info));
                    }
                }
            }
