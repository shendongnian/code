    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            string file = openFileDialog1.FileName;
            try
            {
                using (var reader = new StreamReader(file))
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
        //Whatever code you use to check your number
    }
