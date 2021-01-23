    foreach (string item in Directory.GetFiles("c:/test/", "*.*").Select(Path.GetFileName())
        {
            if (!omitNames.Contains(item))
            {
                Console.WriteLine("Adding " + item.Name + " to localFiles.");
                localFiles.Add(item.Name);
                Console.WriteLine("Item added to localFiles.");
            }
        }
