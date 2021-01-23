    static void Main(string[] args)
    {
        List<string> list1 = new List<string>();
        list1.Add("The Avengers");
        list1.Add("Shutter Island");
        list1.Add("Inception");
        list1.Add("The Dark Knight Rises");
        List<string> list2 = new List<string>();
        list2.Add("The Avengers");
        list2.Add("Shutter Island");
        list2.Add("Inception");
        list2.Add("The Dark Knight Rises");
        list2.Add("Parks and Recreation");
        list2.Add("Scandal");
        List<string> difference = list2.Except(list1).ToList();
        foreach (var value in difference)
        {
            Console.WriteLine(value);
        }
        Console.ReadLine();
    }
