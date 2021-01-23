    class MyStack<T> : Stack<T> // yeuch
    {
        public void Add(T item)
        {
            Push(item);
        }
    }
    ...
    // please don't do this... think of the kittens...
    Stack<string> stack = new MyStack<string>() { "abc", "demo", "stackoverflow" };
