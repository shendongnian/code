    public class Car
    {
        LicensePlate _license;
        public Car(LicensePlate license)
        {
            _license = license;
        }
        public LicensePlate License
        {
            get { return _license; }
        }
    }
