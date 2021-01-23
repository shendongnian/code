    Console.WriteLine("Your age:");
    try
    {    
         age = Int32.Parse(Console.ReadLine());
    }
    catch(FormatException e)
    {
        MessageBox.Show("You have entered non-numeric characters");
       //Console.WriteLine("You have entered non-numeric characters");
    }
