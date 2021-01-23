    static void Main(string[] args)
    {
        Status status = Status.Default;
        string new_status = "Inactive";
        status = (Status)Enum.Parse(typeof(Status), new_status);
        Console.WriteLine(status.ToString());
        // prints "Inactive"
        status = (Status)1;
        Console.WriteLine(status.ToString());
        // prints "Active"
    }
