        public void Run()
        {
            var allTransactions = new List<Transaction>[20];
            for (int i=0; i < allTransactions.Length; i++)
            {
                allTransactions[i] = new List<Transaction>();
            }
            var a = Array.ConvertAll(allTransactions, x => x.ToArray());
            var s = SerializeToString(a);
            System.Console.WriteLine("{0}", s);
        }
