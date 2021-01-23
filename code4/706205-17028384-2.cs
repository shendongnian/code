    private string Crypt(string input, int m, int d)
    {
        string result = "";
        foreach(chat letter in input)
        {
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
            result += letter;
        }
    
        //shift characters inside a block
        result = result.Substring(m) + result.Substring(0, m);
        return result;  
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        uitvoer.Text = Crypt(invoer.Text, 2, 1);
    }
