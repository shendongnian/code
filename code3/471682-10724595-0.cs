    public class Permissions
    {
        public List<Premissions.Group> Groups { get; set; }
        ...
        public Permissions()
        {
            Groups = new List<Permissions.Group>();
        }
    }
