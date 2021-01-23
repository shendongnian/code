    [Table(Name="dbo.Coordinates")]
    public class Coordinate : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id;
        private int _x;
        private int _y;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        protected void OnPropertyChanging(string name)
        {
            PropertyChangingEventHandler handler = PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(name));
        }
    
        [Column(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if(_id != value)
                {
                    SendPropertyChanging("Id");
                    _id = value;
                    SendPropertyChanged("Id");
                }
            }
        }
        [Column(Storage = "_x", DbType = "Int NOT NULL")]
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if(_x != value)
                {
                    SendPropertyChanging("X");
                    _x = value;
                    SendPropertyChanged("X");
                }
            }
        }
        [Column(Storage = "_y", DbType = "Int NOT NULL")]
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                if(_y != value)
                {
                    SendPropertyChanging("Y");
                    _y = value;
                    SendPropertyChanged("Y");
                }
            }
        }
    }
