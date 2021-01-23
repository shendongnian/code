    public sealed class Node<T> { 
      readonly T m_data;
      readonly Node<T> m_prev;
      readonly Node<T> m_next;
      // Data, Next, Prev accessors omitted for brevity      
      public Node(T data, Node<T> prev, IEnumerator<T> rest) { 
        m_data = data;
        m_prev = prev;
        if (rest.MoveNext()) {
          m_next = new Node(rest.Current, this, rest);
        }
      }
    }
    public static class Node {    
      public static Node<T> Create<T>(IEnumerable<T> enumerable) {
        using (var enumerator = enumerable.GetEnumerator()) {
          if (!enumerator.MoveNext()) {
            return null;
          }
          return new Node(enumerator.Current, null, enumerator);
        }
      }
    }
    Node<string> list = Node.Create(new [] { "a", "b", "c", "d" });
