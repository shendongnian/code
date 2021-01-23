        class A
        {
            public int x { get; set; }
            public int y { get; set; }
        }
        class B
        {
            public int y { get; set; }
            public int z { get; set; }
        }
        static List<A> listA = new List<A>();
        static List<B> listB = new List<B>();
        static void Main(string[] args)
        {
            listA.Add(new A {x = 0, y = 1});
            listA.Add(new A {x = 0, y = 2});
            listB.Add(new B {y = 2, z = 9});
            listB.Add(new B {y = 3, z = 9});
            // get all properties from classes A & B and find ones with matching names and types
            var propsA = typeof(A).GetProperties();
            var propsB = typeof(B).GetProperties();
            var matchingProps = new List<Tuple<PropertyInfo, PropertyInfo>>();
            foreach (var pa in propsA)
            {
                foreach (var pb in propsB)
                {
                    if (pa.Name == pb.Name && pa.GetType() == pb.GetType())
                    {
                        matchingProps.Add(new Tuple<PropertyInfo, PropertyInfo>(pa, pb));
                    }
                }
            }
            
            // foreach matching property, get the value from each element in list A and try to find matching one from list B
            var matchingAB = new List<Tuple<A, B>>();
            foreach (var mp in matchingProps)
            {
                foreach (var a in listA)
                {
                    var valA = mp.Item1.GetValue(a, null);
                    foreach (var b in listB)
                    {
                        var valB = mp.Item2.GetValue(b, null);
                        if (valA.Equals(valB))
                        {
                            matchingAB.Add(new Tuple<A, B>(a, b));
                        }
                    }
                }
            }
            Console.WriteLine(matchingAB.Count); // this prints 1 in this case
        }
