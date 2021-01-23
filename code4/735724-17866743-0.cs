    public class PathNode {
        public string Id;
        public PathNode[] Children = new PathNode[4];
    }
    public class PathFinder : MonoBehaviour {
    public List<PathNode> shortestPath = null;
	
    /// <summary>
    /// Sets shortest path to `candidatePath` if `candidatePath` is shorter
    /// or no shortest path yet.
    /// </summary>
    public void SetShortestPath(List<PathNode> path){
        if(shortestPath == null){
            shortestPath = new List<PathNode>(path);
            return;
        }
        if(path.Count < shortestPath.Count)
            shortestPath = new List<PathNode>(path);
        }
	
    /// <summary>
    /// depth-first shortest path
    /// </summary>
    public void FindShortestPath(PathNode target, List<PathNode> path){
        PathNode next = path[path.Count-1]; //get next node from path
        if(target == next){
            SetShortestPath(path);
            return;
        }
        // dfs - iterate children
        foreach (PathNode node in next.Children){
            if(node!=null){
                path.Add(node);				
                FindShortestPath(target,path);
                path.Remove(node);			
            }
        }
    }
    public PathNode ExampleEdgeCreation(){
        PathNode a = new PathNode{Id="A"};
        a.Children[(int)Direction.Left] = new PathNode{Id="B"};
        return a;
    }
    }
