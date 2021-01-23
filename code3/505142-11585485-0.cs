    public TreeNode[] SearchTree(Tree YourTree, SearchObject SearchingFor)
    {
    	return SearchNode(0, YourTree.RootNode, SearchingFor);//Depth is sent in so that our recursion can keep track of how many parents the node has. This allows us to use simple arrays which are far faster than any alternative serial data storage.
    }
    
    public TreeNode[] SearchNode(int depth, TreeNode YourNode, SearchObject SearchingFor)
    {
    	//Edge case
    
    
    	if (SearchingFor.Matches(YourNode))//Does the node match our search?
    	{
    		return GetHeritage(depth, YourNode);//We get the heritage at the end because it's faster than using a dynamically allocated array for every single recursion we do when only one will ever get used. That practically makes the memory used exponential! Not ot mention all of the slowdown caused by the algorithms required for reallocation.
    	}
    	
    	
    	//Recurse
    	
    	TreeNode[] ret = null;
    	for (int i = 0; i < YourNode.ChildNodes.Length; i++)
    	{
    		//Set the ret temporary variable to our recursion, then see if it is null or not
    		if ((ret = SearchNode(depth+1, YourNode.ChildNodes[i])) != null)
    		{
    			break;//Exit the loop!
    		}
    	}
    	
    	
    	//Return the result
    	
    	return ret;//If we find the correct answer, the loop will break with ret at the correct value.
    	//If, however, we do not find anything correct within this node, we will simply return null.
    }
    
    
    
    //Final calculation for the correct result.
    
    public TreeNode[] GetHeritage(int depth, TreeNode YourNode)//This will list every node starting from the node we found going all the way back to the root node. The first element in the array returned will be the root node.
    {
    	TreeNode[] ret = new TreeNode[depth+1];
    	ret[depth] = YourNode;//Depth is actually one less than our length, so... Hurrah!
    	for (int i = depth; i >= 0; i--)
    	{
    		ret[depth-i] = ret[depth-(i-1)].Parent;
    	}
    	
    	return ret;
    }
