    using (var file = new StreamReader("C://log.txt"))
    {
        var lineCt = 0;
        while (var line = file.ReadLine())
        {
            lineCt++;
            //logic for lines to keep
            if (lineCt == 1 || lineCt == 5)
            {
                Console.WriteLine(line);
            }
        }
    }
