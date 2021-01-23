    class MyClass
    {
        public string Value { get; set; }
    }
    
    Queue<MyClass> queue = new Queue<MyClass>();
    queue.Enqueue(new MyClass() { Value = "1" });
    queue.Peek().Value = 2;
    string value = queue.Peek().Value; // is 2
