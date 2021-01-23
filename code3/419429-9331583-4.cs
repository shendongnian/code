    using System.Linq;
    IQueryable<IMyData> mydata = new List<IMyData>()
        {
            new MyData() { Intdata = 5, DoubleData = 1.2 },
            new MyData() { Intdata = 2, DoubleData = 6.8 }
        }.AsQueryable();
