c#
class MyNode
{
    public MyNode Parent;
    public IEnumerable<MyNode> Elements;
    int group = 1;
    public IEnumerable<MyNode> GetAllNodes()
    {
        if (Elements == null)
        {
            return new List<MyNode>(); 
        }
        return Elements.SelectMany(e => e.GetAllNodes());
    }
}
Now you could ask the top level MyNode to get all the nodes.
    var flatten = topNode.GetAllNodes();
If you can't edit the class, then this isn't an option. But otherwise, I think this is could be preferred of a separate (recursive) LINQ method. 
This is using LINQ, So I think this answer is applicable here ;)
