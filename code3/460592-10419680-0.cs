    public partial class MyEntity
    {    
        public void RaisePropertyChanged(string propertyName)
        {
           this.RaisedPropertyChanged(propertyName);
        }
    }
