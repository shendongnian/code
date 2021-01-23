    public class ShapeWrapper
    {
        public IVisio.Shape Shape { get; set; }
        private List<ShapeWrapper> children = new List<ShapeWrapper>();
        public List<ShapeWrapper> Children { get { return this.children; } }
        public ShapeWrapper(IVisio.Shape shape)
        {
            Shape = shape;
        }
    }
    private void FindChildren(ShapeWrapper shapeWrapper, 
                                  List<IVisio.Shape> addedShapes)
    {
        IVisio.Selection children = shapeWrapper
           .Shape.SpatialNeighbors[
                (short)IVisio.VisSpatialRelationCodes.visSpatialContain, 
                0,
                (short)IVisio.VisSpatialRelationFlags.visSpatialFrontToBack];
        foreach (IVisio.Shape child in children)
        {
            if (!addedShapes.Contains(child))
            {
                 //MessageBox.Show(child.Text);
                 ShapeWrapper childWrapper = new ShapeWrapper(child);
                 shapeWrapper.Children.Add(childWrapper);
                 FindChildren(childWrapper, addedShapes);
            }
        }
    }
