    using (StreamReader sr = new StreamReader("Books.txt"))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            listBox1.Items.Add(line);
        }
    }    
