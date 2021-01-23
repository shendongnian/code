    class Program
    {
        public static void Main()
        {
            Source src = new Source();
            Destination dst = new Destination(src);
            dst.Name = "Destination";
            dst.MyValue = -100;
            src.Value = 50; //changes MyValue as well
            src.Value = 45; //changes MyValue as well
            Console.ReadLine();
        }
    }
    //A way to provide source property to destination property 
    //mapping to the binding engine. Any other way can be used as well
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class BindToAttribute : Attribute
    {
        public string PropertyName
        {
            get;
            private set;
        }
        //Allows binding of different properties to different sources
        public int SourceId
        {
            get;
            private set;
        }
        public BindToAttribute(string propertyName, int sourceId)
        {
            PropertyName = propertyName;
            SourceId = sourceId;
        }
    }
    //INotifyPropertyChanged, so that binding engine knows when source gets updated
    internal class Source : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    Console.WriteLine("Value is now: " + _value);
                    OnPropertyChanged("Value");
                }
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    internal class Destination
    {
        private BindingEngine<Destination> _binder;
        private int _myValue;
        [BindTo("Value", 1)]
        public int MyValue
        {
            get
            {
                return _myValue;
            }
            set
            {
                _myValue = value;
                Console.WriteLine("My Value is now: " + _myValue);
            }
        }
        //No mapping defined for this property, hence it is not bound
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Console.WriteLine("Name is now: " + _name);
            }
        }
        public Destination(Source src)
        {
            //Binder for Source no 1
            _binder = new BindingEngine<Destination>(this, src, 1);
        }
    }
    internal class BindingEngine<T>
    {
        private readonly object _source;
        private readonly T _destination;
        private readonly PropertyDescriptorCollection _sourceProperties;
        private readonly Dictionary<string, PropertyDescriptor> _srcToDestMapping;
        public BindingEngine(T destination, INotifyPropertyChanged source, int srcId)
        {
            _source = source;
            _destination = destination;
            //Get a list of destination properties
            PropertyDescriptorCollection destinationProperties = TypeDescriptor.GetProperties(destination);
            //Get a list of source properties
            _sourceProperties = TypeDescriptor.GetProperties(source);
            //This is the source property to destination property mapping
            _srcToDestMapping = new Dictionary<string, PropertyDescriptor>();
            //listen for INotifyPropertyChanged event on the source
            source.PropertyChanged += SourcePropertyChanged;
            foreach (PropertyDescriptor property in destinationProperties)
            {
                //Prepare the mapping.
                //Add those properties for which binding has been defined
                var attribute = (BindToAttribute)property.Attributes[typeof(BindToAttribute)];
                if (attribute != null && attribute.SourceId == srcId)
                {
                    _srcToDestMapping[attribute.PropertyName] = property;
                }
            }
        }
        void SourcePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Debug.Assert(_source == sender);
            if (_srcToDestMapping.ContainsKey(args.PropertyName))
            {
                //Get the destination property from mapping and update it
                _srcToDestMapping[args.PropertyName].SetValue(_destination, _sourceProperties[args.PropertyName].GetValue(_source));
            }
        }
    }
