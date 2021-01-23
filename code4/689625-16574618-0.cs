    int i;
    bool valid = false;
    do {
    	Console.WriteLine("Enter an int: ");
    	string input = Console.ReadLine();
    	valid = int.TryParse(input, out i);
    } while(! valid);
    
    //use i
