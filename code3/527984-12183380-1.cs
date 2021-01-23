    [DataContract]
    public class HotelDetails
    {
        [DataMember(Name="@order")]
        public string order;
    
        [DataMember(Name="hotelId")]    
        public string hotelId;
    
        [DataMember(Name="name")]  
        public string name;
    
        [DataMember(Name="address1")]  
        public string address1;
    }
