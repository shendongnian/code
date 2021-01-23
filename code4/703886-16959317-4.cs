    public class PersonNameResolver : ValueResolver<Person, string>
    {
        protected override string ResolveCore(Person value)
        {
            return (value == null ? string.Empty : value.FirstName + " " + value.LastName);
        }
    }
