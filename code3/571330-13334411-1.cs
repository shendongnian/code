    public class Item: IEquatable<Item>
    {
        public List<int> val { get; set; }
        public double support { get; set; }
    
        public bool Equals(Item other)
        {
            return
                this.support == other.support &&
                this.val.SequenceEqual(other.val);
        }
    }
