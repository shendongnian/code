    public class ReferenceList<T> : List<IReference<T>> where T : MyAbstractBase
    {
    	public void Add(T item)
    	{
    		base.Add((Reference<T>)item);
    	}
    }
    
    ReferenceList<Shape> shapeList = new ReferenceList<Shape>();
    shapeList.Add(new Circle());
    shapeList.Add(new Shape());
