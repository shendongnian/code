    public IEnumerable<Line> ReadLines(StreamReader sr)
    {
        int number = 0;
        while (true)
        {
            string line = sr.ReadLine();
            if (line == null)
                break;
            ++number;
            if (wantLine(line)) // Some predicate which decides if you want to keep the line.
                yield return new Line{Text = line, Number = number};
        }
    }
