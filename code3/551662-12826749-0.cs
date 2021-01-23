    Queue<string> queue = new Queue<string>();
    Array array = new Button[10];
    queue.CopyTo(array, 0, queue.Count); // Compilation failure...
    ICollection collection = (ICollection) queue;
    collection.CopyTo(array, 0, queue.Count); // Compiles, but will go bang
