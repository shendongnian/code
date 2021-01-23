    [ProtoContract]
    public class NodeItem
    {
        [ProtoMember(1)]
        public char Key { get; set; }
        [ProtoMember(2, AsReference = true)]
        public PrefixTree Value { get; set; }
    }
    [ProtoContract]
    public class Nodes : IDictionary<char, PrefixTree>
    {
        private readonly IDictionary<char, PrefixTree> inner;
        [ProtoMember(1)]
        public NodeItem[] Items
        {
            get
            {
                return this.inner.Select(item => new NodeItem() {Key = item.Key, Value = item.Value}).ToArray();
            }
            set
            {
                foreach( NodeItem item in value)
                {
                    this.inner.Add(item.Key, item.Value);
                }
            }
        }
        ... // Omitted IDictionary members for clarity
