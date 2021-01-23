    var lineCount = File.ReadLines(@"C:\file.txt").Count();
    var reader = new StreamReader(File.OpenRead(@"C:\location1.csv"));
    int[,] properties = new int[lineCount,4];
    for(int i2 = 0; i2 < 4; i2++)
    {
        for(int i = 0; i < lineCount; i++)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            properties[i,i2] = Convert.ToInt32(values[i2];
        }
    }
