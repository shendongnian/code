    public static void Reverse(List<int> lst)
    {
       Stack<int> st1 = new Stack<int>();
       while (lst.Count != 0)
       {
    		var item = lst[0];
    		lst.RemoveAt(0);
            st1.Push(item);
       }
       while (st1.Count != 0)
       {
           lst.Add(st1.Pop());
       }
    }
