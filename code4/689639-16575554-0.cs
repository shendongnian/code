    using System.ComponentModel;
    
    namespace ClassLibrary8 {
        public abstract class CFoo : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
