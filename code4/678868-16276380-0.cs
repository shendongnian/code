        public string FormatClosingTags(string origionalText)
        {
            string manipulate = origionalText;
    
            // Get the tags away from the words.
            manipulate = manipulate.Replace(">", "> ");
            manipulate = manipulate.Replace("<", " <");
    
            // Now that the tags are alone and weak, split them up!
            string[] tags = manipulate.Split(' ');
    
            // Create holding cells to sibigate the tags.
            List<string> openingTags = new List<string>();
            List<string> closingTags = new List<string>();
    
            // Create a marshal to hold the subjugated tags.
            StringBuilder output = new StringBuilder();
    
            // Find all those tags!
            foreach (string s in tags)
            {
                // Make sure its only the women and children
                if ((s.Contains("<") || s.Contains(">")) && (!s.Contains("</")))
                {
                    openingTags.Add(s);
                }
                // While keeping the males to themsleves
                else if ((s.Contains("<") || s.Contains(">")) && (s.Contains("</")))
                {
                    closingTags.Add(s);
                }
            }
    
    
            // Get one of those harsh ladies with a clipboard and make her count all the men
            int counter = closingTags.Count;
    
            // Destroy all the females that have a male
            openingTags.RemoveRange(0, counter);
    
            // Find the rest of the lonely women
            foreach (string open in openingTags)
            {
                // CONVERT THEM TO MEN - add them to the marshal's list
                output.Append(open.Replace("<", "</"));
            }
    
            return origionalText + output;
        }
