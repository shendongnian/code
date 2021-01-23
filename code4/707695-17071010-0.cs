    namespace AppNameSpace  
    {
        [DataContract]              /* Place this inside your app namespace */
        internal class iResponse    /*Name this class appropriately */
        {
            [DataMember]
            internal string field1;
            [DataMember]
            internal string field2;
            [DataMember]
            internal Int32 field3;
        }
        ...
    }
