    public class Level2
    {
        public double price { get; set; }
        public long volume { get; set; }
        public Level2(double price, long volume)
        {
            this.price = price;
            this.volume = volume;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Level2;
            if (other == null)
                return false;
            return other.price == this.price && other.volume == this.volume;
        }
        public override int GetHashCode()
        {
            return price.GetHashCode() ^ volume.GetHashCode();
        }
    }
    static void Main(string[] args)
    {
        List<Level2> ask = new List<Level2>();
        ask.Add(new Level2(200, 500));
        ask.Add(new Level2(300, 400));
        ask.Add(new Level2(300, 600));
        ask.Remove(new Level2(300, 400));
    }
