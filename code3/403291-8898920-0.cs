    public void getBottles()
    {
        string input;
    
		do
        {
            Console.Write("Enter the room you're in: (or quit)");
			input = Console.ReadLine();
			
            int room;
			// doing try parst because the input might be "quit" or other junk
			if (int.TryParse(input, out room))
			{
				Console.Write("Bottles collected in room {0}: ", room);
				// this will fail hard if the input is not of type int
            	rooms[room - 1] += int.Parse(Console.ReadLine());
			}
        } while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase));	
    }
