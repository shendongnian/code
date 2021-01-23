    // Initialize by a default value to avoid
    // "Use of unassigned local variable 'MainMenuSelection'" error
    byte mainMenuSelection = 0x00;    
    string input = Console.ReadLine();
    // If acceptable - remove possible spaces at the start and the end of a string
    input = input.Trim();
    if (input.Lenght != 1)
    {
       // can you do anything if user entered multiple characters?
    }
    else
    {
       if (!byte.TryParse(input, out mainMenuSelection))
       {
           // parsing error
       }
       else
       {
           // ok, do switch
       }
