    public interface IEdge<TPoint>...
    class MyEdge : IEdge<MyPoint>
    {
       IEdgeFactory<MyPoint> factory;
       public MyEdge(IEdgeFactory<MyPoint> factory)
       {
          this.factory = factory;
       }
    }
