    const int N = 5;
    Stack<object> stk = new Stack<object>();
    stk.push(array[0]);
    for (int i = 1; i < array.Length; i++)
    {
         object head = stk.Peek();
         if ( array[i].timestamp > head.timestamp )
         {
             stk.Push(array[i]);
         }        
    
    }
    object[] subset = new object[N];
    for (int i = 0; i < N && stk.Count > 0; i++)
    {
        subset[i] = stk.Pop();
    }
