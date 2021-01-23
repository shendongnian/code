    // call base class constructor before your own executes
    public class B : A
    {
        public B(int whatever)
            : base(something)
        {
            // more code here
        }
    }
    // call secondary constructor
    public class B : A
    {
        private int _something;
        public B() : this(10) { }
        public B(int whatever)
        {
            _something = whatever;
        }
    }
