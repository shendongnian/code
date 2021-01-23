    public class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            Address = new AddressViewModel();
            Address.RegisterPropertyHandler(a => a.ZipCode, ZipCodeChanged);
        }
        private AddressViewModel _address;
        public AddressViewModel Address
        {
            get { return _address; }
            set
            {
                _address = value;
                PropertyChanged.Notify(this, () => Address);
            }
        }
        private static void ZipCodeChanged(object sender, PropertyChangedEventArgs args)
        {
            // This will only be called when the 'ZipCode' property of 'Address' changes.
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class AddressViewModel : INotifyPropertyChanged
    {
        private string _zipCode;
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
                PropertyChanged.Notify(this, () => ZipCode);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
