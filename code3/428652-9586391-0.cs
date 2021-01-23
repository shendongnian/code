    public class AClass
    {
        public int Position { set; get; }
        public int Trending { set; get; }
    }
    List<AClass> list = new List<AClass>() { 
        new AClass() { Position = 1, Trending = 2 }, 
        new AClass() { Position = 2, Trending = 1 } 
    };
    var order1 = list.OrderBy(x => x.Position).ToArray();
    var order2 = list.OrderBy(x => x.Trending).ToArray();
