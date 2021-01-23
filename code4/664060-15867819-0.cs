    int x = 4;   // number of lines you want to get
    var buffor = new Queue<string>(x);
    var file = new StreamReader("Input.txt");
    while (!file.EndOfStream)
    {
        string line = file.ReadLine();
        if (buffor.Count >= x)
            buffor.Dequeue();
        buffor.Enqueue(line);
    }
    string[] lastLines = buffor.ToArray();
    string contentOfLastLines = String.Join(Environment.NewLine, lastLines);
