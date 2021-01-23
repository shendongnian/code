    using(var sr = new StreamReader(File.Open(textBox2.Text, FileMode.Open))
    {
        while (sr.Peek() >= 0) 
        {
            Console.WriteLine(sr.ReadLine());
         }
    }
