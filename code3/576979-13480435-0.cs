    Dictionary<string, string> allTheThings = new Dictionary<string, string>();
    public void ReadIt()
    {
        // Open the file into a streamreader
        using (System.IO.StreamReader sr = new System.IO.StreamReader("text_path_here.txt"))
        {
            while (!sr.EndOfStream) // Keep reading until we get to the end
            {
                string splitMe = sr.ReadLine();
                string[] bananaSplits = splitMe.Split(new char[] { ':' }); //Split at the colons
                if (bananaSplits.Length < 2) // If we get less than 2 results, discard them
                    continue; 
                else if (bananaSplits.Length == 2) // Easy part. If there are 2 results, add them to the dictionary
                    allTheThings.Add(bananaSplits[0].Trim(), bananaSplits[1].Trim());
                else if (bananaSplits.Length > 2)
                    SplitItGood(splitMe, allTheThings); // Hard part. If there are more than 2 results, use the method below.
            }
        }
    }
    public void SplitItGood(string stringInput, Dictionary<string, string> dictInput)
    {
        StringBuilder sb = new StringBuilder();
        List<string> fish = new List<string>(); // This list will hold the keys and values as we find them
        bool hasFirstValue = false;
        foreach (char c in stringInput) // Iterate through each character in the input
        {
            if (c != ':') // Keep building the string until we reach a colon
                sb.Append(c);
            else if (c == ':' && !hasFirstValue)
            {
                fish.Add(sb.ToString().Trim());
                sb.Clear();
                hasFirstValue = true;
            }
            else if (c == ':' && hasFirstValue)
            {
                // Below, the StringBuilder currently has something like this:
                // "    235235         Some Text Here"
                // We trim the leading whitespace, then split at the first sign of a double space
                string[] bananaSplit = sb.ToString()
                                         .Trim()
                                         .Split(new string[] { "  " },
                                                StringSplitOptions.RemoveEmptyEntries);
                // Add both results to the list
                fish.Add(bananaSplit[0].Trim());
                fish.Add(bananaSplit[1].Trim());
                sb.Clear();
            }                    
        }
        fish.Add(sb.ToString().Trim()); // Add the last result to the list
        for (int i = 0; i < fish.Count; i += 2)
        {
            // This for loop assumes that the amount of keys and values added together
            // is an even number. If it comes out odd, then one of the lines on the input
            // text file wasn't parsed correctly or wasn't generated correctly.
            dictInput.Add(fish[i], fish[i + 1]); 
        }
    }
