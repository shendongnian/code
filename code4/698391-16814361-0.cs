    Console.WriteLine("Enter your Name");
    Console.WriteLine("Enter your Pswrd");
    string name = Console.ReadLine();
    string pswrd = Console.ReadLine();
    string[] names = "James,John,Jude".Split(Convert.ToChar(","));
    string[] passes = "Pass1, Word2, Password3".Split(Convert.ToChar(","));
    for (int i = 0; i<names.Length, i++)
    {
        if (names[i] == name && passes[i] == pswrd)
        {
            Console.WriteLine("You are logged in");
        }
        else
        {
            Console.WriteLine("Incorrect name or pswrd");
        }
    }
