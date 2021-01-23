    public class Test
    {
        public static void Main(string[] args)
        {
            ObservableVar<int> five = new ObservableVar<int>(5);
            five.PropertyChanged += VarChangedEventHanler;
            five.Value = 6;
            int six = five;
            if (five == six)
            {
                Console.WriteLine("You can use it almost like regular type!");
            }
            Console.ReadKey();            
        }
        static void VarChangedEventHanler(object sender,PropertyChangedEventArgs e)
        {
            Console.WriteLine("{0} has changed",sender.ToString());
        }
    }
    
    public class ObservableVar<T> : INotifyPropertyChanged
    {
        private T value;
        public ObservableVar(T _value)
        {
            this.value = _value;
        }
        public T Value
        {
            get { return value; }
            set
            {
                if (!this.value.Equals(value)) //null check omitted
                {
                    this.value = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public static implicit operator T(ObservableVar<T> observable)
        {
            return observable.Value;
        }
    }
