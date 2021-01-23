    namespace Eagl.Eagle.Data
    {
        using System;
        using System.ComponentModel;
        using System.Runtime.CompilerServices;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
    
        public partial class Game : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public Game()
            {
                this.Playtests = new ObservableCollection<Playtest>();
            }
    
            public int _Id;
            public int Id
            {
                get { return _Id; } 
                set
                {
                    if (value == _Id) return;
                    _Id = value;
                    NotifyPropertyChanged();
                }
            }
    
            public string _Name;
            public string Name
            {
                get { return _Name; } 
                set
                {
                    if (value == _Name) return;
                    _Name = value;
                    NotifyPropertyChanged();
                }
            }
    
    
            public virtual ObservableCollection<Playtest> Playtests { get; set; }
        }
    }
