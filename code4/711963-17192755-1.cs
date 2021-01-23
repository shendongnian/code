    public class Pair
    {
        public string A { get; set; }
        public string B { get; set; }
    }
    var pairs = new List<Pair>();
    pairs.Add(new Pair { A = "1", B = "2" });
    pairs.Add(new Pair { A = "1", B = "3" });
    pairs.Add(new Pair { A = "1", B = "4" });
    pairs.Add(new Pair { A = "2", B = "1" });
    pairs.Add(new Pair { A = "2", B = "2" });
    pairs.Add(new Pair { A = "2", B = "3" });
    
    var grouping = pairs.GroupBy(x => x.A);
    
    var combinations = grouping.SelectMany(x =>
                                    grouping.Select(y =>
                                        new { Group = x, Combination = y }));
