    public class SomeClass
    {
        public List<SqlParameter> SPPC;
        public SomeClass(someType someParameter)
        {
            SPPC = this.GetType().GetMembers().ToList();
            // Or you could restrict it to only fields or properties using Where()
            SPPC = this.GetType().GetMembers().Where(member => member which is of type such).ToList();
            // Or use Select() to get only the value or the name of the members
            SPPC = this.GetType().GetMembers().Select(member => get member value).ToList();
        }
    }
