       //Data Entry   
        StudentData student1 = new StudentData();   
        Console.WriteLine("name?");   
        student1.name = Console.ReadLine();   
        Console.WriteLine("Roll Number?");   
        student1.rollNo = Convert.ToInt32(Console.ReadLine());   
        Console.WriteLine("Grade");   
        student1.grade = Console.ReadLine();
        //Output   
        Console.WriteLine("Name =\t" + student1.name);   
        Console.WriteLine("Roll No =\t" + student1.rollNo);   
        Console.WriteLine("Grade =\t" + student1.grade);   
        Console.WriteLine("GPA =\t" + student1.gpa); 
        Console.ReadKey();   
