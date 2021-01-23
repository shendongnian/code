    public struct Optional<T>
    {
        public readonly bool ValueProvided;
        public readonly T Value;
        private Optional( T value )
        {
            this.ValueProvided = true;
            this.Value = value;
        }
        public static implicit operator Optional<T>( T value )
        {
            return new Optional<T>( value );
        }
    }
