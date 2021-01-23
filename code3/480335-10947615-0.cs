    class Program
    {
        class X
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        class XequalityComparer : IEqualityComparer<X>
        {
            //Note: maybe add a null check in these methods
            public bool Equals(X x, X y) { return x.Id.Equals(y.Id); }
            public int GetHashCode(X obj) { return obj.Id.GetHashCode(); }
        }
        static void Main(string[] args)
        {
            var instanceOne = new List<X>() { 
                new X() { Id = Guid.NewGuid() }, 
                new X() { Id = Guid.Parse("EF42EE32-1B9E-493C-9D39-4610E0FB29D0") } 
            };
            var instanceTwo = new List<X>() { 
                new X() { Id = Guid.NewGuid() }, 
                new X() { Id = Guid.Parse("EF42EE32-1B9E-493C-9D39-4610E0FB29D0") } 
            };
            var common = instanceOne.Intersect(instanceTwo, new XequalityComparer());
        }
    }
