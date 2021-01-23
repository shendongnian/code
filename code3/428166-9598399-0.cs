    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
        public string DisplayName { get; set; }
    }
    public interface ISendOut
    {
        void Send(string data);
    }
    [DisplayName("Wireless")]
    public class WirelessSendOut : ISendOut
    {
        public void Send(string data)
        {
            MessageBox.Show("data sent through wireless.");
        }
    }
    [DisplayName("Serial")]
    public class SerialSendOut : ISendOut
    {
        public void Send(string data)
        {
            MessageBox.Show("data sent through serial port.");
        }
    }
    public static class SendOutFactory
    {
        public static ISendOut CreateSendOut(string typeName)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var sendOutType = types.First(x => (typeof(ISendOut)).IsAssignableFrom(x) && x.Name == typeName);
            return (ISendOut) Activator.CreateInstance(sendOutType);
        }
    }
    public static class SendOutDiscovery
    {
        public static IEnumerable<NameType> Discover()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var sendOutTypes = types.Where(x => x != typeof(ISendOut) && (typeof(ISendOut)).IsAssignableFrom(x));
            return sendOutTypes.Select(type => GetNameType(type)).ToList();
        }
        private static NameType GetNameType(Type type)
        {
            var nameType = new NameType
                               {
                                   DisplayName = GetDisplayName(type),
                                   TypeName = type.Name
                               };
            return nameType;
        }
        private static string GetDisplayName(Type type)
        {
            return ((DisplayNameAttribute)type.GetCustomAttributes(typeof (DisplayNameAttribute), false).First()).DisplayName;
        }
    }
    public class NameType //for binding in UI
    {
        public string DisplayName { get; set; }
        public string TypeName { get; set; }
    }
    public class SendOutViewModel //sample using in wpf (window contains a combobox)
    {
        public SendOutViewModel()
        {
            SendTypes = new ObservableCollection<NameType>(SendOutDiscovery.Discover());
        }
        public NameType SelectedSendType { get; set; } //bind to selected item in combobox
        
        public ObservableCollection<NameType> SendTypes { get; private set; } //bind to item source of combo
        public string Data { get; set; } //data to be sent
        public void Send()
        {
            ISendOut sendOut = SendOutFactory.CreateSendOut(SelectedSendType.TypeName);
            sendOut.Send(Data);
        }
    }
