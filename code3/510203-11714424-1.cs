    public class Program
    {
        public static void Main(string[] args)
        {
            // start the main procedure asynchron
            Task.Run(() => DoIt()).Wait();
        }
        // for async support since the static main method can't be async
        public static async void DoIt()
        {
            Program p = new Program();
            
            // use the methods
            string s = await p.GetString();
            int i = await p.GetInt();
            Task<string> tsk = await p.GetTaskOfString();
            // just to prove the task works:
            // C# 5
            string resultFromReturnedTask = await tsk;
            // C# 4
            string resultFromReturnedTask2 = tsk.Result;
        }
        public async Task<string> GetString()
        {
            return "string";
        }
        public async Task<int> GetInt()
        {
            return 6;
        }
        public async Task<Task<string>> GetTaskOfString()
        {
            return Task.Run(() => "string");
        }
    }
