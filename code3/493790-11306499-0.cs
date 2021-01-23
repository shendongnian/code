    interface IParent {
        ...
    }
    
    class Node {
        public IParent Parent {get; set;}
    }
    
    class File : Node {
        ...
    }
    
    class CategoryNode : Node, IParent {
        ...
    }
