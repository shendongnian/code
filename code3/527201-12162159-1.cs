    public class Node
    {
        public string Name;
        public string Address;
        public int Id;
        public List<Node> Children;
        public Node Parent;
        public Node()
        {
            this.Children = new List<Node>();
        }
        public string CompareId
        {
            get
            {
                var temp = string.Concat(this.Name, this.Address, this.Id);
                if (this.Parent == null)
                    return temp;
                else
                    return string.Concat(temp, this.Parent.CompareId);
            }
        }
        public override bool Equals(object OtherNode)
        {
            if (OtherNode is Node)
                return this.CompareId.Equals(((Node)OtherNode).CompareId);
            else
                return false;
        }
        public static Node RemoveDuplicatesFromTree(Node RootNode)
        {
            if (RootNode.Children.Count > 0)
            {
                List<Node> OldChildrenList = new List<Node>();
                OldChildrenList.AddRange(RootNode.Children);
                foreach (Node CurrentChild in OldChildrenList)
                {
                    if (RootNode.Children.Any<Node>(x => x.Equals(CurrentChild)))
                    {
                        List<Node> Duplicates = RootNode.Children.Where(x => x.Equals(CurrentChild)).ToList<Node>();
                        Duplicates.ForEach(x =>
                            {
                                CurrentChild.Children = CurrentChild.Children.Union<Node>(x.Children).ToList<Node>();
                                RootNode.Children.Remove(x);
                            });
                        RootNode.Children.Add(CurrentChild);
                    }
                    Node.RemoveDuplicatesFromTree(CurrentChild);
                }
            }
            
            return RootNode;
        }
    }
