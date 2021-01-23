        static void Main(string[] args)
        {
            // data
            List<Int32> listElement = new List<Int32>() { 10, 20, 10, 30, 45, 10, 20, 30, 40, 50, 60, 40, 30, 50, 60, 70, 80, 90, 20, 30, 10, 50, 60, 40, 60, 80, 90, 60, 80, 70, 80, 90, 90, 50 };
            Int32 MaxStack = 180;
            // result
            List<List<Int32>> listResult = new List<List<Int32>>();
            // process
            foreach (Int32 element in listElement.OrderByDescending(i => i))
            {
                List<Int32> listToStore = listResult.Where(l => l.Sum() + element <= MaxStack).FirstOrDefault();
                if (listToStore == null)
                {
                    listToStore = new List<Int32>();
                    listResult.Add(listToStore);
                }
                listToStore.Add(element);
            }
            // view
            foreach (List<Int32> list in listResult)
            {
                Console.Write("List " + (listResult.IndexOf(list) + 1) + "[total " + list.Sum() + "]: ");                
                foreach (Int32 element in list)
                {
                    Console.Write(element.ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
