    public class Node<T>
    {
      private List list;
      private Node<T> prev, next;
      public List List { get { return list; } }
      // other accessors.
    
      public abstract class List
      {
        Node<T> head;
    
        internal List() { }
    
        public AddFirst(Node<T> node)
        {
            // node adding logic.
            node.list = this;       
        }
        // implementation elided for brevity
      }
    
    }
    
    public class MyLinkedList<T> : Node<T>.List { }
