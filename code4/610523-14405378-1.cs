    private void button1_Click(object sender, EventArgs e)
    {
        // No need of IF Statements to reverse a Boolean
        parametri.Light1 = !parametri.Light1;
        Char[] characters = parametri.Light1.ToString().ToCharArray();
        characters[0] = Char.ToUpper(characters[0]);
        label1.Text = new String(characters);
    }
