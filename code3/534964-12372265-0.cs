        public class MyClass
        {
            public int Value { get; set; }
        }
        static void Main(string[] args)
	    {
            Queue<MyClass> q = new Queue<MyClass>();
            q.Enqueue(new MyClass { Value = 1 });
            var i = q.Peek();
            i.Value++;
            i = q.Peek();
            Console.WriteLine(i.Value);
        }
