    [StructLayout(LayoutKind.Sequential)]
    [DataContract]
    public struct Invoice_Body_Item
    {
        [DataMember]
        public string Item_Description;
        [DataMember]
        public decimal Item_Value;
    }
