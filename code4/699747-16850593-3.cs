    public class Node<T>
    {
            // Private member-variables
            private T data;//This member variable contains the data stored in the node of the type specified by the developer using this class.
            private NodeList<T> neighbors = null; //of type `NodeList<T>`. This member variable represents the node's children.
    
            public Node() {}
            public Node(T data) : this(data, null) {}
            public Node(T data, NodeList<T> neighbors)
            {
                this.data = data;
                this.neighbors = neighbors;
            }
    
            public T Value
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
    
            protected NodeList<T> Neighbors
            {
                get
                {
                    return neighbors;
                }
                set
                {
                    neighbors = value;
                }
            }
        }
    }
