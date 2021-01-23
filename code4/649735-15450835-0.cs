    public class Vertex : IEquatable<Vertex>
    {
        public string Name { get; private set; }
    
        public Vertex(string name)
        {
            Name = name;
        }
    
        public override int GetHashCode()
        {
            return StringComparer.InvariantCulture.GetHashCode(Name);
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex);
        }
    
        public bool Equals(Vertex obj)
        {
            return obj != null && StringComparer.InvariantCulture.Equals(Name, obj.Name);
        }
    }
    
