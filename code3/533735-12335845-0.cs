    using System.Collections.Generic;
    using System.Linq;
    
    public class MyModel
    {
        public List<long> TotalItems
        {
            get
            {
                return ItemsApples.Concat(ItemsOranges).Concat(ItemsPeaches).ToList(); // all lists conbined, including duplicates
                //return ItemsApples.Union(ItemsOranges).Union(ItemsPeaches).ToList(); // set of all items
            }
        }
    
        public List<long> ItemsApples { get; set; }
    
        public List<long> ItemsOranges { get; set; }
    
        public List<long> ItemsPeaches { get; set; }
    
        public void CombineItems()
        {
            
        }
    }
