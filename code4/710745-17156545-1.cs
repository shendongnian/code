    public class GenericNode<T> where T : IConvertible
    {
     public T item;
     public GenericNode<T> next;
     public GenericNode()
     { 
     }
     public GenericNode(T item)
     {
        this.item = item;
     }
    }
    void Main()
    {
     GenericNode<string> node = new GenericNode<string>("one");
     GenericNode<int> node2 = new GenericNode<int>(1);
    }
