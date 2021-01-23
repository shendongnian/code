    int numlines = 0;
    using (var reader = new StreamReader("list1.txt")) {
        while (!reader.EndOfStream) {
            Console.WriteLine(reader.ReadLine().Trim());
            numlines++;
        }
    }
    Console.WriteLine("Wrote " + numlines + " lines.");
    Console.Read();
