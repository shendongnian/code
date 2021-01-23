    Stack<int> stack = new Stack<int>();
    int i;
    // int i = 0;
    stack.Push(0);                   // push 0
    i = stack.Pop();                 // pop 0 --> i == 0
    // i += i++;
    stack.Push(i);                   // push 0
    stack.Push(i);                   // push 0
    stack.Push(i);                   // push 0
    stack.Push(1);                   // push 1
    i = stack.Pop() + stack.Pop();   // pop 0 and 1 --> i == 1
    i = stack.Pop() + stack.Pop();   // pop 0 and 0 --> i == 0
