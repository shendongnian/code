    static void findStudentmark()
    {
        Console.WriteLine("Please Enter The Students Name To Find Their Marks");
        Console.WriteLine("Please Press Enter To Continue");
        string stdName = Console.ReadLine();
        int i = 0;
        for (i = 0; i < StudentNames.Length; i++)
        {
            if (string.Compare(stdName, StudentNames[i], true)==0)
            {
                break;
            }
        }
        Console.WriteLine(StudentNames[i]);
        Console.WriteLine(StudentMarks[i]);
    }
        static void printStudentsmarks()
        {
            Console.WriteLine("\nStudent Mark List");
            for (int i = 0; i < StudentNames.Length; i++)
            {
                Console.Write("Name: ");
                Console.WriteLine(StudentNames[i]);
                Console.WriteLine("Marks: ");
                Console.WriteLine(StudentMarks[i]);
                Console.WriteLine("______________________________");
            }
            Console.WriteLine("Please Press Enter To Continue");
            Console.ReadLine();
            promptForStudentQuery();
        }
