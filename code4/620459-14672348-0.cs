    var files = new List<string>()
    	{
    		"File1", "File2", "File3", "File4",
    	};
    
    foreach (var fsi in files)
    	Console.WriteLine(fsi); //printing the "files" list
    
    // A counter to save the specific position
    int cnt = 0;
    Console.SetCursorPosition(0, cnt);//setting initial place of cursor
    
    // Save the pressed key so you dont need to press it twice
    ConsoleKey key;
    while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape)  //untill i press escape
    {
    	switch (key)
    	{
    		case ConsoleKey.DownArrow:   //for Down key
    			cnt++;
    
    			if (cnt >= files.Count)
    			{
    				cnt = files.Count - 1;
    			}
    
    			Console.BackgroundColor = ConsoleColor.Blue;
    			Console.ForegroundColor = ConsoleColor.Green;
    
    			// Here's the problem, the cursor goes to the end of the list, 
    			// not moving through each item:
    			Console.SetCursorPosition(0, cnt);
    
    			break;
    
    		case ConsoleKey.UpArrow:   //for Down key
    			cnt--;
    
    			if (cnt < 0)
    			{
    				cnt = 0;
    			}
    
    			Console.BackgroundColor = ConsoleColor.Blue;
    			Console.ForegroundColor = ConsoleColor.Green;
    
    			// Here's the problem, the cursor goes to the end of the list, 
    			// not moving through each item:
    			Console.SetCursorPosition(0, cnt);
    
    			break;
    
    	}
    }
    Console.ReadKey();
