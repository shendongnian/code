    public abstract class CustomerBase
    {
        public abstract string FirstName { get; }
        public abstract string LastName { get; }
        internal abstract void SetFirstName(string name);
        internal abstract void SetLastName(string name);
    }
