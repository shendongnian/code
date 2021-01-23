    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            string file = openFileDialog1.FileName;
            try
            {
                string text = File.ReadAllText(file);
                using (var reader = new StringReader(text))
                {
                    using (var writer = new StreamWriter("results.txt"))
                    {
                        string currentNumber;
                        while ((currentNumber = reader.ReadLine()) != null)
                        {
                            if (IsNumberValid(currentNumber))
                                writer.WriteLine(String.Format("{0} true", currentNumber));
                        }
                    }
                }
            }
    
            catch (IOException)
            {
            }
        }
    }
    
    public bool IsNumberValid(string number)
    {
        int result;
        return Int32.TryParse(number, out result);
    }
