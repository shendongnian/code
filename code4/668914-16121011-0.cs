          public void breadthFirst(Edge graph, LinkedList<String> visited) 
            {
                LinkedList<String> nodes = graph.adjacentNodes(visited.Last());
                // examine adjacent nodes
                foreach (String node in nodes) 
                {
                    if (visited.Contains(node)) {
                        continue;
                }
                if (node.Equals(endNode)) {
                    visited.AddLast(node);
                    printPath(visited);
                    visited.RemoveLast();
                    RouteCounter++;
                    break;
                }
            }
            // in breadth-first, recursion needs to come after visiting adjacent nodes
            foreach (String node in nodes) {
                if (visited.Contains(node) || node.Equals(endNode)) {
                    continue;
                }
                visited.AddLast(node);
                breadthFirst(graph, visited);
                visited.RemoveLast();
            }
        }
    
    usage would be like this:
     Dijkstra d = new Dijkstra(_edges, _nodes);
     LinkedList<String> visited = new LinkedList<string>();  //collecting all routes
     visited.AddFirst(start);
     d.breadthFirst(graph, visited); 
