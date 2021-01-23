            List<string> lines = new List<string>((string[])richTextBox1.Invoke(new Func<string[]>(delegate { return richTextBox1.Lines; } )) );
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
