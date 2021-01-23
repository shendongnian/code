    struct Foo : IEquatable<Foo>
    {
        public bool Equals(Foo other)
        {
            // Do your equality test here.
            throw new NotImplementedException();
        }
        public bool Equals(object other)
        {
            if (other != null && other is Foo) {
                return Equals((Foo)other);
            }
            return false;
        }
    }
