    int[] linesAsNumbers = new int[richTextBox1.Lines.Length]; // We'll store the numbers in this array
    
    int i = 0; // Keep an index of where to place the incoming numbers
    foreach (string line in richTextBox1.Lines)
    {
        linesAsNumbers[i++] = Convert.ToInt32(line); // Convert each line into a number and store it into our newly created array
    }
