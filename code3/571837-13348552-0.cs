    public ValidationRule1 : ValidationRule
    {
        public override IFailure ToFailure()
        {
            return new Failure1(this);
        }
        
        ...
    }
