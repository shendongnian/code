    List<string> player_names = new List<string>();
    do {
        Console.WriteLine("Enter the players name: ");
        player_name = Console.ReadLine();
        player_names.Add(player_name);
        Console.WriteLine("Would you like to enter another player? y/n");
    } while (Console.ReadLine() == "y");
    foreach (string name in player_names) {
      Console.WriteLine(name);
    }
