    private void ReadFile()
    {
        try
        {
            string line = null;
            System.IO.TextReader readFile = new StreamReader("C:\\csharp.net-informations.txt");
            while (true)
            {
                line = readFile.ReadLine();
                if (line != null)
                {
                    MessageBox.Show(line);
                }
            }
            readFile.Close();
            readFile = null;
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
