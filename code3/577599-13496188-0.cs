    void Main()
    {
            var part1 = new Part {PartNo = "part1", Price = 10};
            var part2 = new Part {PartNo = "part1", Price = 8};
            var part3 = new Part {PartNo = "part1", Price = 12};
    
            var parts = new List<Part> {part1, part2, part3};
    
            var lowest = parts.Min(p => p.Price );
    
            var result = parts.Select (p => string.Format("Part #:{0} {1} -> {2}", p.PartNo, p.Price,  ((p.Price/lowest)-1)*100 ));
    
          result.ToList()
                .ForEach(rs => Console.WriteLine (rs));
            /*
    Part #:part1 10 -> 25.00
    Part #:part1 8 -> 0
    Part #:part1 12 -> 50.0
    */
    
    
    }
    
    // Define other methods and classes here
    public class Part
    {
        public string PartNo { get; set; }
        public decimal Price { get; set; }
    }
