    public static List<T> GetSubSet<T>(List<T> incomingList)
    {
        var returnList = new List<T>();
        Random r = new Random();
        Console.WriteLine("Enter size of random subset: ");
        int randomInt = 0;
        int size = Convert.ToInt32(Console.ReadLine());
        while (size > incomingList.Count)
        {
            Console.WriteLine("Size too large, enter smaller subset: ");
            size = Convert.ToInt32(Console.ReadLine());
        }
        while (returnList.Count < size)
        {
            randomInt = r.Next(incomingList.Count);
            if (!returnList.Contains(incomingList[randomInt]))
            {
                returnList.Add(incomingList[randomInt]);
            }
        }
        return returnList;
    }
