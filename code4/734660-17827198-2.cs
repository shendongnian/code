    public class OtherItemNode : INode<object>
    {
        public bool Equals(INode<object> other)
        {
            throw new NotImplementedException();
        }
        public int Id { get; set; }
        public object GetId()
        {
            return Id;
        }
    }
