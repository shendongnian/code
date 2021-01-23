            static void Main(string[] args)
            {
    
                var task1 = Task.Factory.StartNew(()=>{foreach (var n in Back1(13)) Console.WriteLine("From Back 1, said "+n);});
                var task2 = Task.Factory.StartNew(() => { foreach (var n in Back2(5)) Console.WriteLine("From Back 2, said " + n); });
                task1.Wait();
                task2.Wait();
                Console.WriteLine("All done");
                Console.ReadLine();
            }
            static IEnumerable<string> Back1(int it)
            {
                for (int i = 0; i < it; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    yield return i +" of "+it;
                }
                yield return "I'm done";
                
                
            }
    
            static IEnumerable<string> Back2(int it)
            {
                for (int i = 0; i < it; i++)
                {
                    System.Threading.Thread.Sleep(150);
                    yield return i +" of "+it;
                }
                yield return "I'm done";
            }
