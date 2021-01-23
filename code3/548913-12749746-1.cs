    [Test]
    public void X()
    {
        var list1 = new List<Alpha> {new Alpha {Bravo = 1}, new Alpha {Bravo = 1}, new Alpha {Bravo = 2}};
        var list2 = new List<Alpha> { new Alpha { Bravo = 1 }, new Alpha { Bravo = 3 }, new Alpha { Bravo = 5 } };
        var alphaComparer = new AlphaComparer();
        Assert.AreEqual(1, list1.Intersect(list2, alphaComparer).Count());
        Console.WriteLine("Equals count = {0}; GetHashCode count = {1}", alphaComparer.EqualsCallCount, alphaComparer.GetHashCodeCallCount);
    }
    class Alpha
    {
        public int Bravo { get; set; }
    }
    class AlphaComparer : IEqualityComparer<Alpha>
    {
        public int EqualsCallCount { get; private set; }
        public int GetHashCodeCallCount { get; private set; }
        public bool Equals(Alpha x, Alpha y)
        {
            EqualsCallCount += 1;
            return x.Bravo.Equals(y.Bravo);
        }
        public int GetHashCode(Alpha obj)
        {
            GetHashCodeCallCount += 1;
            return obj.Bravo.GetHashCode();
        }
