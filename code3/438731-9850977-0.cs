    public class A<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        T value;
        int max;
        string dataType;
        bool nullable;
        bool isKey;
        bool isIdentity;
    }
    
    public class B : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public B()
        {
            A<int> objA = new A<int>();
        }
    }
