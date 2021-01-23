    public class Permissions
    {
        public Permissions()
        {
             Groups = new List<Group>();
        }
    
        public ICollection<Group> Groups { get; set; }
    }
