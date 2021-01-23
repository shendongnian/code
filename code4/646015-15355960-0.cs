    //I don't think you have to do this. Instead, you can iterate through `users`
    string[] textLines1 = new List<string>(users).ToArray();
    double totalTime = 0;
    int count = 0;
    //For each line
    foreach (string line in textLines1) {
        //Here we match against this line
        var m = Regex.Match(line, @"Elapsed Time:\s*(?<value>\d+\.?\d*)\s*ms");
        //If it matched...
        if (m.Success) {
            try
            {
                count++;
                double time = Double.Parse(m.Groups["value"].Value);
                totalTime += time;
            }
            catch (Exception)
            {
                // no number
            }
        }
    }
    double average = totalTime / count;
    Console.WriteLine("ADVAverage=" + average);
