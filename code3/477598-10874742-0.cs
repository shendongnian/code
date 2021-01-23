    int counter = 0; 
    while (true) {
        Console.WriteLine("Do you want to copy ...");
        string choice = Console.ReadLine();
        if (choice == "x") {
            break;
        }
        if (choice == "y") {
            // Copy the file
        } else {
            Console.WriteLine("Invalid choice!");
        }
        counter++;
    }
