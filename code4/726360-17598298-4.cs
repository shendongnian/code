    public static class TaskExtension
    {
        /// <summary>
        /// Call to highlight fact that you do not want to wait on this task.
        ///
        /// This nicely removes resharper warnings without need for comments.
        /// </summary>
        /// <param name="task"></param>
        public static void FireAndForget(this Task task)
        {
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cancellationToken = new CancellationTokenSource();
            TaskCode(cancellationToken.Token).FireAndForget();
            Console.ReadLine();
            cancellationToken.Cancel();
            Console.WriteLine("End");
            Console.ReadLine();
        }
        private static async Task TaskCode(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var interval = TimeSpan.FromSeconds(1);
                await Task.Delay(interval, cancellationToken);
                //SOME WORK HERE
                Console.WriteLine("Tick");
            }
        }
    }
