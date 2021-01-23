    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Progres...  ");
            Progress<int> progress = new Progress<int>();
            var task = Alg(progress);            
            progress.ProgressChanged += (s, i) => { UpdateProgress(i); };
            task.Start();
            task.Wait();
        }
        public static void UpdateProgress(int iteration)
        {
            string anim = @"|/-\-";
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(anim[iteration % anim.Count()]);
        }
        public static Task Alg(IProgress<int> progress)
        {
            Task t = new Task
            (
                () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(50);
                        ((IProgress<int>)progress).Report(i);
                    }
                }
            );
            return t;
        }
    }
