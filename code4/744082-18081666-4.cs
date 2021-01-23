    // Note: sealed to avoid oddities around equality and inheritance
    public sealed class Vertex : IEquatable<Vertex>
    {
        public Vertex(Point point)
        {
            VertexLabel = point;
        }
        public Point VertexLabel { get; private set; }
        public override int GetHashCode()
        {
            return VertexLabel.GetHashCode();
        }
        public override bool Equals(object obj)
        { 
            return Equals(obj as Vertex);
        }
        public bool Equals(Vertex vertex)
        {
            return vertex != null && vertex.VertexLabel.Equals(VertexLabel);
        }
    }      
