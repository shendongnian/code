    public partial class hotels : object
    {
        private int countfield;
        private ObservableCollection<hotel> hotelfield;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0, ElementName="foundHotels")]
        public int count
        {
            get
            {
                return this.countfield;
            }
            set
            {
                this.countfield = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1,ElementName="hotel")]
        public ObservableCollection<hotel> hotel
        {
            get
            {
                return this.hotelfield;
            }
            set
            {
                this.hotelfield = value;
            }
        }
        // other fields
    }
    public partial class hotel : object, System.ComponentModel.INotifyPropertyChanged
    {
        private int hotIdField;
        private int hoyIdField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public int hotId
        {
            get
            {
                return this.hotIdField;
            }
            set
            {
                this.hotIdField = value;
                this.RaisePropertyChanged("hotId");
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public int hoyId
        {
            get
            {
                return this.hoyIdField;
            }
            set
            {
                this.hoyIdField = value;
                this.RaisePropertyChanged("hoyId");
            }
        }
        // other properties
    }
