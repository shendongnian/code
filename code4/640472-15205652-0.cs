    public IEnumerable<long> GetAllParentIdsOf(MyRecursiveObject obj)
    {
         Stack<MyRecursiveObject> stack = new Stack<MyRecursiveObject>();
         stack.Push(obj);
    
         while(stack.Count > 0)
         {
             var child = stack.Pop();
             yield return child.Id;
             if (child.Parent != null)
                 stack.Push(child.Parent);
         }
    }
