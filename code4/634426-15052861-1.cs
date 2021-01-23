    public void Print()
    {
        Console.WriteLine(name);
        foreach (Student s in students)
            Console.WriteLine(s.Name + ", " + s.Age);
    }
