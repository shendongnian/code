    [DataContract]
    public class StoreListJsonDTO
    {
        [DataMember(Name = "stores")]
        public List Stores { get; set; }
        
        public StoreListJsonDTO(List storeList)
        {
            this.Stores = storeList;
        }
    }
