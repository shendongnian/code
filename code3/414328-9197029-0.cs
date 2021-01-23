    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread starts and sleeps");
            Student stu = new Student();
            ThreadPool.QueueUserWorkItem(stu.Display, 7);
            ThreadPool.QueueUserWorkItem(stu.Display, 6);
            ThreadPool.QueueUserWorkItem(stu.Display, 5);
    
            // barrier here
            Console.WriteLine("Main thread ends");
        }
    }
