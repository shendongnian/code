    public class Level2
    {
        public double price { get; set; }
        public long volume { get; set; }
        public Level2(double price, long volume)
        {
            this.price = price;
            this.volume = volume;
        }
    }
    static void Main()
    {
        List<Level2> bid = new List<Level2>();
        bid.Add(new Level2(200, 500));
        bid.Add(new Level2(300, 400));
        bid.Add(new Level2(300, 600));
        foreach (Level2 item in bid.Where(x => x.price==300 && x.volume == 400))
        {
            bid.Remove(item);
            Console.WriteLine("removing " + item.ToString());
        }
    }
