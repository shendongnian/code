    class MessageSpecification : Specification<string>
    {
        public const int MIN_LENGTH = 5;
        public const int MAX_LENGTH = 60;
        public override bool IsSatisfiedBy(string s)
        {
            Specification<string> length = new LengthSpecification(MIN_LENGTH, MAX_LENGTH);
            Specification<string> isNull = new IsNullSpecification<string>();
            Specification<string> spec = length && !isNull;
            return spec.IsSatisfiedBy(s);
        }
    }
