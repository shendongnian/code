    do
    {
        // Poll use microseconds, waits 1 second
        if (listener.Poll(1000000, SelectMode.SelectRead)) 
        {
           // the socket is accept/able
           Socket handler = listener.Accept();
           etc ...
        }
        //i wanna catch an Escape key here
        ConsoleKeyInfo keyx = Console.ReadKey(true);
        while (keyx.Key != ConsoleKey.Escape) 
        etc ...
    } while (true);
