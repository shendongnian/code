    List<IStudent> students = new List<IStudent>();
    students.Add(new PrimaryStudent());
    students.Add(new SecondaryStudent());
    students.Add(new HightSchoolStudent());
    foreach (IStudent student in students)
    {
        if (student is PrimaryStudent)
        {
            Console.WriteLine("This was a PrimaryStudent");
        }
        else if (student is SecondaryStudent)
        {
            Console.WriteLine("This was a SecondaryStudent");
        }
        else if (student is HightSchoolStudent)
        {
            Console.WriteLine("This was a HightSchoolStudent");
        }
    }
    Console.Read();
