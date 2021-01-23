        var list = new[]{ new Item
        {
            P1 = 0,
            Q1 = 0,
            P2 = 3,
            Q2 = 1,
        },
        new Item
        {
            P1 = 0,
            Q1 = 0,
            P2 = 2,
            Q2 = 1,
        }
    };
    var query = list.AsQueryable();
    var result = query.EuclideanDistanceOrder(new Expression<Func<Item, double>>[]{
        x => x.P1,
        x => x.P2
    },
    new Expression<Func<Item, double>>[]{
        x => x.Q1,
        x => x.Q2
    }).ToArray();
    internal class Item
    {
        public double P1 { get; set; }
        public double Q1 { get; set; }
        public double P2 { get; set; }
        public double Q2 { get; set; }
    }
