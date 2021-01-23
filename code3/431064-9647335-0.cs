    Dictionary<string, Student> dict = new Dictionary<string, Student>();
    dict.Add("Dave", Dave);
    dict.Add("Mike", Mike);
    string surname = Console.ReadLine();
    dict[surname].DisplayDetails();
