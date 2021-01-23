    public class Subclass : Observable
    {
        int property;
        public int Property
        {
            get
            {
                return property;
            }
            set
            {
                property = value;
                NotifyPropertyChanged(()=>Property);
            }
        }
    }
