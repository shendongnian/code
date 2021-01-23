    public class NodeList : SortedList<int, List<NodeInfo>>
    {
        public void Add(int key, NodeInfo info)
        {
            if (this.Keys.Contains(key))
            {
                this[key].Add(info);
            }
            else
            {
                this.Add(key, new List<NodeInfo>() { info } );
            }
        }
        public NodeInfo FirstNode()
        {
            if (this.Count == 0)
                return null;
            return this.First().Value.First();
        }
    }
    public class NodeInfo
    {
        public string Info { get; set; }
        // TODO: add other members
    }
