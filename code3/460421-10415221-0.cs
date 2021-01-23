    public struct MyStruct
    {
        public MyStruct(Person p)
        {
            this.p = p;
        }
        private Person p;
        public Person Person
        {
            get
            {
                if (p == null)
                {
                    p = new Person(…); // see comment below about struct immutability
                }
                return p;
            }
        }
        // ^ in most other cases, this would be a typical use case for Lazy<T>;
        //   but due to structs' default constructor, we *always* need the null check.
    }
