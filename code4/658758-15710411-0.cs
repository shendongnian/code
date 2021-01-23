    public static int GetDepth(Expression t)
    {
        //This stack stores a node that has yet to be processed along with the
        //depth of that node.
        var stack = new Stack<Tuple<Expression, int>>();
        stack.Push(Tuple.Create(t, 0));
        int max = 0;
        while (stack.Any())
        {
            var next = stack.Pop();
            foreach (var child in GetDirectChildren(next.Item1))
            {
                stack.Push(Tuple.Create(child, next.Item2 +1));
            }
            //you only need to run this if there are no children, 
            //but I didn't bother to not run it if there are any 
            //as it won't cause harm either way
            max = Math.Max(max, next.Item2);
        }
        return max;
    }
