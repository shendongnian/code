    string line = "This is a really long run-on sentence that should go for longer than 150 characters and will need to be split into two lines, but only at a word boundary.";
    int maxLength = 150;
    string delimiter = "\r\n";
    List<string> lines = new List<string>();
    // As long as we still have more than 'maxLength' characters, keep splitting
    while (line.Length > maxLength)
    {
        // Starting at this character and going backwards, if the character
        // is not part of a word or number, insert a newline here.
        for (int charIndex = (maxLength); charIndex > 0; charIndex--)
        {
            if (char.IsWhiteSpace(line[charIndex]))
            {
                // Split the line after this character 
                // and continue on with the remainder
                lines.Add(line.Substring(0, charIndex+1));
                line = line.Substring(charIndex+1);
                break;
            }
        }
    }
    lines.Add(line);
    // Join the list back together with delimiter ("\r\n") between each line
    string final = string.Join(delimiter , lines);
    
    // Check the results
    Console.WriteLine(final);
