    public class ReadOnlyNode<T>
    {
       public readonly T Value;
       public readonly ReadOnlyNode<T> Next;
       public readonly ReadOnlyNode<T> Prev;
    
       public Node(T value, ReadOnlyNode<T> next, ReadOnlyNode<T> prev)
       {
          Value = value;
          Next = next;
          Prev = prev;
       }
    }
