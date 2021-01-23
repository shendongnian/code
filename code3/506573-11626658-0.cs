    grading gpa;
    if (Enum.TryParse(student1.grade.ToString(), true, out gpa))
    {
        student1.gpa = (float)(int)gpa;
        Console.WriteLine("Name =\t" + student1.name);
        Console.WriteLine("Roll No =\t" + student1.rollNo);
        Console.WriteLine("Grade =\t" + student1.grade);
        Console.WriteLine("GPA =\t" + student1.gpa);
    }
    else
    {
        Console.WriteLine("You entered an invalid letter grade");
    }
