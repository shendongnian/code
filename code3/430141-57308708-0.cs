    class Program
    {
        static void Main(string[] args)
        {
            // fake rest API
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            // GET data from api & map to Poco
            var todo =  url.GetJsonFromUrl().FromJson<Todo>();
            // print result to screen
            todo.PrintDump();
        }
        public class Todo
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public bool Completed { get; set; }
        }
    }
