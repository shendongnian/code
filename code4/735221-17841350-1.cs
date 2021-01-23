    class Itemm
    {
        public int Id { get; set; }
    }
    
    static void Main(string[] args)
    {
        List<Itemm> BoughtItems = new List<Itemm>() { new Itemm { Id = 1 }, new Itemm { Id = 2 } };
        List<Itemm> equippedItems = new List<Itemm>() { new Itemm { Id = 1 } };
        var result = BoughtItems.Where(x => equippedItems.Any(any => any.Id == x.Id));
        foreach (var el in result)
            Console.WriteLine(el.Id);
    }
