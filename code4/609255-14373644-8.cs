    public enum AuthourType
    {
        Novelist,
        Other
    }
    public interface IAuthor
    {
        string Name { get; set; }
        AuthourType Type { get; set; }
    }
    public class  Novelist : IAuthor
    {
        public string Name { get; set; }
        public AuthourType Type { get; set; }
        // incase u dont want it to be set to other value
        /*        
        public AuthourType Type
        {
            get { return type; }
            set
            {
                if (value != AuthourType.Novelist)
                {
                    throw new NotSupportedException("Type");
                }
                type = value;
            }
        }
        */
    }
