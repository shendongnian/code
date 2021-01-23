    // assume that System.IO is included (in a using statement)
    // reads the file, changes all leading integers to "Number", and writes the changes
    void rewriteNumbers(string file)
    {
        // get the lines from the file
        string[] lines = File.ReadAllLines(file);
        // for each line, do:
        for (int i = 0; i < lines.Length; i++)
        {
            // trim all number characters from the beginning of the line, and
            // write "Number" to the beginning
            lines[i] = "Number" + lines[i].TrimStart('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
        }
        // write the changes back to the file
        File.WriteAllLines(file, lines);
    }
