    class A
    {
        public int Integer { get; set; }
    }
    class B
    {
        public int Integer { get; set; }
    }
    class Program
    {
        public static void main(string[] args)
        {
            var a = new[] { new A { Integer = 5 }, new A { Integer = 6 }, new A { Integer = 7 } };
            var b = new[] { new B { Integer = 1 }, new B { Integer = 2 }, new B { Integer = 3 } };
            var u = a.Cast<dynamic>().Union(b).ToArray();
            var i1 = u[0].Integer;
            var i2 = u[1].Integer;
            var i3 = u[2].Integer;
            var i4 = u[3].Integer;
            var i5 = u[4].Integer;
            var i6 = u[5].Integer;
        }
    }
