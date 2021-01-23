    using (StreamReader r = new StreamReader("Test.txt"))
    {
        using (StreamWriter w = new StreamWriter("TestOut.txt"))
        {
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                w.WriteLine(line);
                if (line == ":020000020000FC")
                    w.WriteLine(":020000098723060");
            }
            w.Close();
            r.Close();
        }
    }
