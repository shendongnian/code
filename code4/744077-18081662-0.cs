    public class Vertex
    {
        public Vertex(Point point)
        {
            VertexLabel = point;
        }
    
        public Point VertexLabel { get; private set; }
        
        public override int GetHashCode()
        {
            return VertexLabel.X + VertexLabel.Y;
        }
        public override bool Equals(object obj)
        {
            //your logic for comparing Vertex
        }
    }
