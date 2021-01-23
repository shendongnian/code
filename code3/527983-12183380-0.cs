    [DataContract]
    public class HotelDetails
    {
        [DataMember("@order")]
        public string order;
    
        [DataMember("hotelId")]    
        public string hotelId;
    
        [DataMember("name")]  
        public string name;
    
        [DataMember("address1")]  
        public string address1;
    }
