    class Program
    {
      static void Main(string[] args)
      {
         Node<int, string> node1 = new Node<int, string>(1, "One");
         Node<int, string> node2 = new Node<int, string>(2, "Two");
         Node<int, string> node3 = new Node<int, string>(3, "Three");
         Node<int, string> node4 = new Node<int, string>(4, "Four");
         node2.Parent = node1;
         node3.Parent = node1;
         node4.Parent = node2;
         Console.WriteLine(node1.GetDump());
         Node<int, string> node5 = new Node<int, string>(5, "Five");
         // Test spliting the tree attaching it and it's subtree to another parent
         node2.Parent = node5;
         Console.WriteLine(node1.GetDump());
         Console.WriteLine(node5.GetDump());
         // Test re-attaching the detached parent as a child
         node1.Parent = node2;
         Console.WriteLine(node5.GetDump());
         // Test moving a node to another parent within the tree
         node1.Parent = node5;
         Console.WriteLine(node5.GetDump());
      }
    }
    /// <summary>
    /// Create a tree structure whose nodes are of type T and are indexed by ID type I
    /// </summary>
    /// <typeparam name="I">Type of the index</typeparam>
    /// <typeparam name="T">Type of the node</typeparam>
    class Node<I, T>
    {
      private Dictionary<I, Node<I, T>> rootIndex; // Shared flat index
      public I Id { get; private set; }
      public T Value { get; set; }
      private Node<I, T> parent;
      List<Node<I, T>> childNodes;
      public Node(I id, T value)
      {
         this.Id = id;
         this.Value = value;
         this.childNodes = new List<Node<I, T>>();
      }
      public string GetDump()
      {
         System.Text.StringBuilder sb = new StringBuilder();
         if (parent == null)
         {
            foreach (KeyValuePair<I, Node<I,T>> node in rootIndex)
            {
               sb.Append(string.Format("{0}:{1} ", node.Key, node.Value.Value));
            }
            sb.AppendLine();
         }
         sb.AppendLine(string.Format("ID={0}, Value={1}, ParentId={2}", Id, Value,
            (parent == null)?"(null)":parent.Id.ToString()));
         foreach (Node<I, T> child in childNodes)
         {
            string childDump = child.GetDump();
            foreach (string line in childDump.Split(new string[] {Environment.NewLine},
               StringSplitOptions.RemoveEmptyEntries))
            {
               sb.AppendLine("  " + line);
            }
         }
         return sb.ToString();
      }
      private void RemoveFromIndex(Dictionary<I, Node<I, T>> index)
      {
         index.Remove(Id);
         foreach(Node<I, T> node in childNodes)
            node.RemoveFromIndex(index);
      }
      private void ReplaceIndex(Dictionary<I, Node<I, T>> index)
      {
         rootIndex = index;
         rootIndex[Id] = this;
         foreach (Node<I, T> node in childNodes)
            node.ReplaceIndex(index);
      }
      public Node<I, T> Parent
      {
         get
         {
            return parent;
         }
         set
         {
            // If this node was in another tree, remove it from the other tree
            if (parent != null)
            {
               // If the tree is truly a separate tree, remove it and all nodes under
               // it from the old tree's index completely.
               if (value == null || (parent.rootIndex != value.rootIndex))
               {
                  // Split the child's index from the parent's
                  Dictionary<I, Node<I, T>> parentRootIndex = parent.rootIndex;
                  RemoveFromIndex(parentRootIndex);
                  rootIndex = new Dictionary<I, Node<I, T>>();
                  ReplaceIndex(rootIndex);
               }
               // Remove it from it's old parent node's child collection
               parent.childNodes.Remove(this);
            }
            // These operations only apply to a node that is not being removed
            // from the tree
            if (value != null)
            {
               // If parent does not already have an index, create one with itself listed
               if (value.rootIndex == null)
               {
                  value.rootIndex = new Dictionary<I, Node<I, T>>();
                  value.rootIndex[value.Id] = value;
               }
               // If the index for the child node is separate form that of the parent
               // node, merge them as appropriate
               if (this.rootIndex != value.rootIndex)
               {
                  // If this node has a complete index, merge the two tree indexes
                  // into the parent's index
                  if (this.rootIndex != null)
                  {
                     foreach (KeyValuePair<I, Node<I, T>> node in rootIndex)
                     {
                        if (value.rootIndex.ContainsKey(node.Key))
                           throw new InvalidOperationException(string.Format(
                             "Node Id {0} in child tree already exists in the parent",
                             node.Key));
                        value.rootIndex[node.Key] = node.Value;
                     }
                  }
                  else
                  {
                     // If this node does not have an index, it is not a tree;
                     // just add it to the parent's index.
                     if (value.rootIndex.ContainsKey(this.Id))
                        throw new InvalidOperationException(string.Format(
                        "Node Id {0} already exists in the parent's tree.", Id));
                     value.rootIndex[this.Id] = this;
                  }
               }
               // Make all nodes in a tree refer to a common root index.
               this.rootIndex = value.rootIndex;
               // Attach this node to the tree via the parent's child collection.
               value.childNodes.Add(this);
            }
            // Attach this node to the tree via this node's parent property
            // (null if removing from the tree)
            this.parent = value;
         }
      }
    }
