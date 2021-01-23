    public class ItemVO: ICloneable
      {
        public ItemVO()
        {
            ItemId = ""; 
            ItemCategory = ""; 
        }
       
        public string ItemId { get; set; }
        public string ItemCategory { get; set; }
    
        public object Clone()
        {
            return new ItemVO
            {
                ItemId = this.ItemId,
                ItemCategory = this.ItemCategory
            }; 
        }
     }
