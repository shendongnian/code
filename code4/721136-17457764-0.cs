        public static List<T> GetSubSet<T>(List<T> incomingList)
        {
            Random r = new Random();
            List<T> returnList = new List<T>();
            Console.WriteLine("Enter random subset size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            while (size > incomingList.Count)
            {
                Console.WriteLine("Size too large.  Enter random subset size: ");
                size = Convert.ToInt32(Console.ReadLine());
            }
            while (returnList.Count < size)
            {
                int randomInt = r.Next(incomingList.Count);
                if (!returnList.Contains(incomingList[randomInt]))
                {
                    returnList.Add(incomingList[randomInt]);
                }
            }
            return returnList;
        }
