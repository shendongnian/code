    class Pool
    {
        private IShape _InnerShape;
        private IShape _OuterShape;
        
        public Pool(IShape inner, IShape outer)
        {
            _InnerShape = inner;
            _OuterShape = outer;
        }
        public double GetRequiredArea()
        {
            return _InnerShape.GetArea() - _OuterShape.GetArea();
        }
    
      }
