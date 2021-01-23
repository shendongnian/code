    public class OctreeNode
    {
        public bool IsLeaf { get; private set; }
        public OctreeNode[8] Children { get; private set; }
        public OctreeNode()
        {
            this.IsLeaf = true;
            this.Children = null;
        }
        // Don't forget to implement methods to build up the tree and split the node when required.
        // Splitting results in a tree structure. Inside the split-method 
        // you need to allocate the Children-Array and set the IsLeaf-Property to false.
        public bool Intersects(Line rayline, ref ICollection<OctreeNodes> Nodes)
        {
            Interval interval;
            // If the current node does not intersect the ray, then we do not need to
            // investigate further on from here.
            if (!Rhino.Geometry.Intersect.Intersection.LineBox(rayline, this.GetBoundingBox(), 0, out interval))
            {
                return false;
            }
            // If this is a leaf (in which we are interested in) we add it to 
            // the nodes-collection.
            if (this.IsLeaf)
            {
                Nodes.Add(this);
                return true;
            }
            // Not a leaf, but our box intersects with the ray, so we need to investigate further.
            for (int i = 0; i < 8; ++i)
            {
                // Recursive call here, but the result doesn't actually matter.
                this.Children[i].Intersects(rayline, Nodes)
            }
            // The ray intersects with our current node.
            return true;
        }
    }
