    [KnownType(typeof(BitmapImage))]
    [DataContract]
        public class MyDataContract
        {
            [DataMember]        
            public BitmapImage MyProperty { get; set; }
        }
