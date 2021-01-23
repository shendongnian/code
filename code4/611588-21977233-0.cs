    [ProtoContract(AsReferenceDefault = true)]
    public class TEST
    {
        [ProtoMember(1018)]
        public List<TEST> _Items { get; set; }
        [ProtoMember(1001, AsReference = true)]
        public TEST Parent;
        [ProtoMember(1003)]
        public string NameItemType;
        public void AddItem(TEST Item)
        {
            _Items.Add(Item);
            Item.Parent = this;
        }
        public TEST()
        {
        }
    }
