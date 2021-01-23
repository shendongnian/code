    private static void Main()
    {
        // Go through each KnownFolder enum entry
        foreach (KnownFolder knownFolder in Enum.GetValues(typeof(KnownFolder)))
        {
            // Write down the current and default path
            Console.WriteLine(knownFolder.ToString() + "");
            try
            {
                Console.Write("Current Path: ");
                Console.WriteLine(KnownFolders.GetPath(knownFolder));
                Console.Write("Default Path: ");
                Console.WriteLine(KnownFolders.GetDefaultPath(knownFolder));
            }
            catch (ExternalException ex)
            {
                // While uncommon with personal folders, other KnownFolders don't exist on every
                // system, and trying to query those returns an error which we catch here
                Console.WriteLine("<Exception> " + ex.ErrorCode);
            }
            Console.WriteLine();
        }
    }
