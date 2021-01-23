    public class Project
    {
        public string Name {get; set;}
        public string Path {get; set;}
        public Project(string Name, string Path = "")
        {
           this.Name = Name;
           this.Path = Path;
        }
    }
