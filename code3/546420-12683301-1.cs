    // Get the line count then loop and populate array
    int lineCount = textBox1.GetLineFromCharIndex(textBox1.Text.Length) + 1;
    
    // Build array of lines
    string[] lines = new string[lineCount];
    for (int i = 0; i < lineCount; i++)
    {
        int start = textBox1.GetFirstCharIndexFromLine(i);
        int end = i < lineCount - 1 ? 
            textBox1.GetFirstCharIndexFromLine(i + 1) :
            textBox1.Text.Length;                            
        lines[i] = textBox1.Text.Substring(start, end - start);
    }
