    [AttributeUsage(AttributeTargets.Property)]
    public class MyAttribute : Attribute
    {
        public string TheString { get; private set; }
        public MyAttribute(string theString)
        {
            this.TheString = theString;
        }
    }
    const string FirstNameIsRequiredThing = "First Name is required";
    [MyAttribute(FirstNameIsRequiredThing)]
    public string FirstNameIsRequired
    {
        get
        {
            return ResourceManager.GetValue(FirstNameIsRequiredThing);
        }
    }
