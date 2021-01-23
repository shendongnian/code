    public class Node
    {
        public string Name { get; set; }
        public abstract void Add(Node child);
        protected abstract void CreateOnDisk();
    }
    public class File
    {
        public override void Add(Node child)
        {
             //No op, since you can't add a child to a file
        }
        
        protected override void CreateOnDisk()
        {
            File.Create(this.Name);
        }
    }
    public class Directory
    {
        public override void Add(Node child)
        {
            child.Name = Path.Combine(this.Name, child.Name);
            child.CreateOnDisk();
        }
        protected override CreateOnDisk()
        {
            Directory.Create(this.Name);
        }
    }
