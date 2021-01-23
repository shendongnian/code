    int counter = 0;
    string line;
    
    Console.Write("Input your search text: ");
    var text = Console.ReadLine();
    
    System.IO.StreamReader file =
        new System.IO.StreamReader("SampleInput1.txt");
    
    while ((line = file.ReadLine()) != null)
    {
        if (line.Contains(text))
        {
            break;
        }
    
        counter++;
    }
    
    Console.WriteLine("Line number: {0}", counter);
    
    file.Close();
    
    Console.ReadLine();
