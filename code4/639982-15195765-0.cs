    private static List<object> _lst;
        static void Main(string[] args)
        {
            Task tsk =  new Task(() => _lst = new List<object>());
            tsk.Start();
            tsk.Wait();
            _lst.Add(1);
        }
