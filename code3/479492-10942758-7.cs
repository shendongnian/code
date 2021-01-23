        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; ++i)
            {
                Func<Func<int, Task<String>>, Task<int>> t =
                    a => a(20).ContinueWith(ta => 
                        ta.IsCanceled ? GetCanceledTask<int>() : 
                        Task.FromResult(ta.Result.Length + 10)).Unwrap();
                Console.WriteLine(Peirce(t).Result); // output 20
                t = a => Task.FromResult(10);
                Console.WriteLine(Peirce(t).Result); // output 10
            }
        }
