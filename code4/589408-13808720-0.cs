    while((string line = sr.ReadLine()) != null)
    {
        if(line.StartsWith(StudentID))
            Console.Write(line);
    }
