    public class Either<A, B>
    {
        A _a;
        B _b;
        bool _isLeft;
    
        private Either() { }
        private Either(A a, B b, bool isLeft)
        {
            _isLeft = isLeft;
    
            if (_isLeft)
            {
                _a = a;
                return;
            }
    
            _b = b;
        }
        public Either(A a) : this(a, default(B), true) { }
        public Either(B b) : this(default(A), b, false) { }
    
        public A Left { get { return _a; } }
        public B Right { get { return _b; } }
        public bool HasLeft { get { return _isLeft; } }
    }
