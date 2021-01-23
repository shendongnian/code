    Console.WriteLine("Your age:");
    try
    {
    
            age = Int32.Parse(Console.ReadLine());
    }
    catch(FormatException e)
    {
    MessageBox.Show("U r entering non-numeric characters");
    //Console.WriteLine("U r entering non-numeric characters");
    }
