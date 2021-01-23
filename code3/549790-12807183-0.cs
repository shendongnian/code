    class GraphNode {
        List<GraphEdge> Edges = new List<GraphEdge>();
        public void AddEdge(GraphEdge edge) {
            Edges.Add(edge);
        }
        //you get the idea, this should have much more
        //it also manages edge connections
    }
    class GraphEdge { //this is a one way connection
        GraphNode ConnectedTo = null;
        //GraphNode ConnectedFrom = null; //if you uncomment this, it can be a two-way
                                          //connection, but you will need more code to
                                          //manage it
        float Cost = 0f;
        //you might consider adding a destructor that clears the pointers
        //otherwise gc might have a hard time getting rid of the nodes
    }
    class Graph {
        List<GraphNodes> Nodes = new List<GraphNodes>();
        //this class manages the nodes
        //it also provides help for connecting nodes
    }
