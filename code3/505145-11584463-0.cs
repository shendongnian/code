    public static void Main()
            {
                Task<int> t = new Task<int>(() => { return Sum(5); });
                t.Start();
                t.Wait();
                t.ContinueWith((task) => { Console.WriteLine(task.Result); });
                //Console.WriteLine(t.Result); //this works
                Console.ReadLine();
            }
