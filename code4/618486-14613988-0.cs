    class Derived : Base
    {
        // all the code you had above, plus this:
        public Derived(Base toCopy)
        {
            this.name = toCopy.name;
            this.address = toCopy.address;
        }
    }
    Derived d = new Derived(b);
