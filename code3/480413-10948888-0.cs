    string line = "This is a really long run-on sentence that should go for longer than 150 characters.  This will need to be split at a word boundary.";
    List<string> lines = new List<string>();
    int maxLength = 80; // Set this to 150, or whatever else you need
                        // ... the console was wrapping on me with 150
                        // ... characters so I reduced the number in my
                        // ... test.
    
    // As long as we still have more than 'maxLength' characters, keep splitting
    while (line.Length > maxLength)
    {
        // Starting at this character and going backwards, if the character
        // is not part of a word or number, insert a newline here.
        for (int charIndex = (maxLength+1); charIndex > 0; charIndex--)
        {
            if (!char.IsLetterOrDigit(line[charIndex]))
            {
                // Split the line here and continue on with the remainder
                lines.Add(line.Substring(0, charIndex));
                line = line.Substring(charIndex);
                break;
            }
        }
    }
    lines.Add(line);
    // Join the list back together with "\r\n" between each line
    string final = string.Join("\r\n", lines);
    
    // Check the results
    Console.WriteLine(final);
