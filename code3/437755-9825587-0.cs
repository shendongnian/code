    public class Node
    {
    }
    
    public class DerivedNode : Node
    {
    }
    
    public class Graph<T>
    	where T : Node
    {
    	private List<T> nodes;
    
    	//some code
    }
    
    public class DerivedGraph : Graph<DerivedNode>
    {
    }
