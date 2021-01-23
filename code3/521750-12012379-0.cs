    public class Item : IComparer
    {
    public Item(int value) { this.Value = value; }
       public int Value { get; set; }
    
           public int CompareTo(Item item)
      {
                     int ret = -1;
            if (Value < item.Value)
                ret = -1;
            else if (Value > item.Value)
                ret = 1;
            else if (Value == item.Value)
                ret = 0;
            return ret;
          }
    
    }
