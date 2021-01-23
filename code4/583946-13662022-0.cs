    do
    {
        while (!Console.KeyAvailable) //Continue if pressing a Key press is not available in the input stream
        {
            //Do Something While Paused
        }
    } while (Console.ReadKey(true).Key != ConsoleKey.Escape); //Stop if Escape was pressed
