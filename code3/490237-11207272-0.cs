    public class HierarchyNode
    {
        private decimal UserId;
        private List<HierarchyNode> ChildNodes;
        public List<HierarchyNode> IdentifySubNodeOfRequestedNode(int reqstedId)
        {
            if (this.UserId == reqstedId)
            {
                return this.ChildNodes;
            }
            return this.ChildNodes.
                Select(childNode => childNode.IdentifySubNodeOfRequestedNode(reqstedId)).
                FirstOrDefault(children => children != null);
        }
    }
