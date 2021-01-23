    Console.WriteLine("Please enter password:");
    string input = Console.ReadLine();
    
    bool PassWordMatch = input == "Test";
    if(PassWordMatch)
       Console.WriteLine(" Password Match. Access Granted");
    else
       Console.WriteLine("Password doesn't match! Access denied.");
