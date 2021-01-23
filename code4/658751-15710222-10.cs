     static void RightRecursiveToString(Node node,  StringBuilder sb)
     {
         // Again, assuming either zero or two children.
         var stack = new Stack<Node>();
         stack.Push(node);
         while(stack.Peek().Left != null)
         {
             sb.Append("(");
             stack.Push(stack.Peek().Left);
         }
         while(stack.Count != 0)
         {
             Node current = stack.Pop();
             sb.Append(current.Value);
             if (current.Right != null)
                 RightRecursiveToString(node.Right);
                 sb.Append(")");
             }
         }
     }
