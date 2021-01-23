    public interface INode<T> : IEquatable<INode<T>>
    {
        T GetId();
    }
    
    public class PersonNode : INode<string>
    {
        public bool Equals(INode<string> other)
        {
            throw new NotImplementedException();
        }
    
        public string GetId()
        {
            throw new NotImplementedException();
        }
    }
    
    public class WorkItemNode : INode<int>
    {
        public int GetId()
        {
            throw new NotImplementedException();
        }
    
        public bool Equals(INode<int> other)
        {
            throw new NotImplementedException();
        }
    }
