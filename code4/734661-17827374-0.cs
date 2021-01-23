    public class WorkItemNode : INode
    {
        public int GetId() //is always int
        {
            ...
            // return the int
        }
        object INode.GetId()  //explicit implementation
        {
            return GetId();
        }
        ...
    }
