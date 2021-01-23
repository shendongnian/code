    IEnumerable<string> lines = File.ReadLines("myLargeFile.txt");
    foreach (string line in lines) {
        string lineInt = line;
        (new Thread(() => {
            if (lineInt.Contains(keyword)) {
                Console.WriteLine(lineInt);
            }
        })).Start();
    }
