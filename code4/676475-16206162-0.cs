     static void Main(string[] args)
            {
                var searcher = Search("test").Subscribe(Console.WriteLine);
                Console.WriteLine("Done");
                Console.ReadLine();
            }
    
    
            private static  IObservable<string[]> Search(string searchTerm)
            {
                var searchClient = new Service1Client();
               
                return Task<string[]>.Factory.FromAsync(searchClient.BeginGetData, searchClient.EndGetData, searchTerm, null).ToObservable();
            }
