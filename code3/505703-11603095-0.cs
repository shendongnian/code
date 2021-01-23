    public class StockItem {
        public string Name { get; set; }
        public int Count { get; set; }
        public override string ToString() {
            if (Count > 1)
                return Name + " x" + Count;
            return Name;
        } 
    }
