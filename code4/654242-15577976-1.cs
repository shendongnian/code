    struct Foo : IEquatable<Foo>
    {
        public bool Equals(Foo other)
        {
            // Do your equality test here.
            throw new NotImplementedException();
        }
        public override bool Equals(object other)
        {
            if (other != null && other is Foo) {
                return Equals((Foo)other);
            }
            return false;
        }
        // If you also want to overload the equality operator:
        public static bool operator==(Foo a, Foo b)
        {
            return a.Equals(b);
        }
        public static bool operator!=(Foo a, Foo b)
        {
            return !a.Equals(b);
        }
    }
