    public class Level2
    {
        public double price { get; set; }
        public long volume { get; set; }
        public Level2(double price, long volume)
        {
            this.price = price;
            this.volume = volume;
        }
        public override string ToString()
        {
            return String.Format("Level 2 object with price: {0} and volume: {1}", 
                this.price, this.volume);
        }
    }
    public static void Main()
    {
        List<Level2> bid = new List<Level2>();
        bid.Add(new Level2(200, 500));
        bid.Add(new Level2(300, 400));
        bid.Add(new Level2(300, 600));
        bid.Add(new Level2(300, 400)); // second item with these quantities
        List<Level2> toRemove = 
            bid.Where(x => x.price == 300 && x.volume == 400).ToList<Level2>();
        foreach (Level2 item in toRemove)
        {
            bid.Remove(item);
            Console.WriteLine("removing " + item.ToString());
        }
    }
