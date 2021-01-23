    public void ReadFile() {
       
        TextReader reder = File.OpenText(@"help.txt");
        richTextBox1.Text = reder.ReadToEnd();        
    }
