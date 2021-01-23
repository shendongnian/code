    private string Crypt(string input, int m, int d)
    {
        // make a block from the string
        char[] buffer = input.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            // Letter.
            char letter = buffer[i];
            // Add shift to all.
            letter = (char)(letter + d);
            // Subtract 26 on overflow.
            // Add 26 on underflow.
            if (letter > 'z')
            {
                letter = (char)(letter - 26);
            }   
            else if (letter < 'a')
            {
                letter = (char)(letter + 26);
            }
            // Store.
            buffer[i] = letter;
        }
    
        //shift characters inside a block
        string shift = string.Concat(buffer.Skip(m).Concat(buffer.Take(m)));
        return shift;  
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        uitvoer.Text = Crypt(invoer.Text, 2, 1);
    }
