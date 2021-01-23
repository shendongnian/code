        private static void Main(string[] args)
        {
            List<DataKeys> dataRepository = new List<DataKeys>()
                                                {
                                                    new DataKeys(10, "Key-10"),
                                                    new DataKeys(11, "Key-11"),
                                                    new DataKeys(9, "Key-9"),
                                                    new DataKeys(8, "Key-8"),
                                                    new DataKeys(100, "Key-100")
                                                };
            dataRepository.Sort();
            foreach (var dataKeyse in dataRepository)
            {
                Console.WriteLine(dataKeyse.Key);
            }
        }
