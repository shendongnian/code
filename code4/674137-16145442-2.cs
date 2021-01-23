    try
    {
        using (StreamReader reader = new StreamReader("fff")){}
    }
    catch(ArgumentException argumentEx)
    {
        Console.WriteLine("The path that you specified was invalid");
        Debug.Print(argumentEx.Message);
    
    }
    catch (FileNotFoundException fileNotFoundEx)
    {
        Console.WriteLine("The program could not find the specified path");
        Debug.Print(fileNotFoundEx.Message);
    }
     
