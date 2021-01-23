    class B : A<X>, IConvertible<Y>
    {
        public override X Convert()
        {
            throw new NotImplementedException();
        }
        Y IConvertible<Y>.Convert()
        {
            throw new NotImplementedException();
        }
    }
