    static void ParseTop(string contentOfOutput)
    {
        var line = contentOfOutput.Split('\n');
        //parse uptime/user/load.avg
        var lineUud = line[0].Substring("top -".Length);
        var wordsUud = lineUud.Split(new[] { "up", "user", "load average:", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        //00:00:00 up 0  days, 17:51,  1 user,  load average: 0.00, 0.01, 0.05
        //^0          ^1 ^2    ^3      ^4                     ^5    ^6    ^7
        //00:00:00 up 0  min,  1 user,  load average: 0.00, 0.01, 0.05
        //^0          ^1 ^2    ^3                     ^4    ^5    ^6
        var time = TimeSpan.Parse(wordsUud[0]);
        if (wordsUud[2] == "days")
        {
            var uptime = TimeSpan.Parse(wordsUud[1] + "." + wordsUud[3] + ":00");
            var users = int.Parse(wordsUud[4]);
            var la1Min = float.Parse(wordsUud[5]);
            var la5Min = float.Parse(wordsUud[6]);
            var la15Min = float.Parse(wordsUud[7]);
        }
        else
        {
            var uptime = TimeSpan.Parse("00:" + wordsUud[1] + ":00");
            var users = int.Parse(wordsUud[3]);
            var la1Min = float.Parse(wordsUud[4]);
            var la5Min = float.Parse(wordsUud[5]);
            var la15Min = float.Parse(wordsUud[6]);
        }
        //parse tasks
        var lineTasks = line[1].Substring("Tasks:".Length);
        var wordTasks = lineTasks.Split(new[] { "total", "running", "sleeping", "stopped", "zombie", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        //70 total,   1 running,  69 sleeping,   0 stopped,   0 zombie
        //^0          ^1          ^2             ^3           ^4
        var totalTasks = int.Parse(wordTasks[0]);
        var runningTasks = int.Parse(wordTasks[1]);
        var sleepingTasks = int.Parse(wordTasks[2]);
        var stoppedTasks = int.Parse(wordTasks[3]);
        var zombieTasks = int.Parse(wordTasks[4]);
        //parse cpu
        var cpus = new Dictionary<string, Dictionary<string, float>>();
        var cpuLineIndex = 2;
        string cpuLine;
        while ((cpuLine = line[cpuLineIndex]).StartsWith("%Cpu"))
        {
            var wordCpu = cpuLine.Split(new[] { "%Cpu", ":", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            //%Cpu(s):  0.2 us,  0.6 sy,  0.0 ni, 99.1 id,  0.0 wa,  0.0 hi,  0.1 si,  0.0 st
            //%Cpu1  :  0.2 us,  0.6 sy,  0.0 ni, 99.1 id,  0.0 wa,  0.0 hi,  0.1 si,  0.0 st
            //    ^0    ^1  ^2   ^3  ^4   ^5  ^6  ^7   ^8   ^9  ^10  ^11 ^12  ^13 ^14  ^15 ^16
            var cpu = new Dictionary<string, float>();
            foreach (var entry in wordCpu.Skip(1).Batch(2).Where(p => p.Count() == 2).Select(p => p.ToArray()))
            {
                cpu[entry[1]] = float.Parse(entry[0]);
            }
            cpus[wordCpu[0]] = cpu;
            cpuLineIndex++;
        }
        //parse memory/swap
        var memories = new Dictionary<string, Dictionary<string, int>>();
        var memLineIndex = cpuLineIndex;
        string memLine;
        while ((memLine = line[memLineIndex]).StartsWith("KiB"))
        {
            var wordMem = memLine.Split(new[] { "KiB", ":", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            //KiB Mem:    993780 total,   968936 used,    24844 free,   418236 buffers
            //KiB Swap:   524284 total,        0 used,   524284 free,   506312 cached
            //    ^0      ^1     ^2       ^3     ^4      ^5     ^6      ^7     ^8
            var mem = new Dictionary<string, int>();
            foreach (var entry in wordMem.Skip(1).Batch(2).Where(p => p.Count() == 2).Select(p => p.ToArray()))
            {
                mem[entry[1]] = int.Parse(entry[0]);
            }
            memories[wordMem[0]] = mem;
            memLineIndex++;
        }
        //parse process
        var process = new List<Dictionary<string, string>>();
        var lineNumOfBlank = Array.IndexOf(line, "");
        var headers = line[lineNumOfBlank + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (var i = lineNumOfBlank + 2; i < line.Length - 1; i++)
        {
            var li = line[i];
            var strings = li.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var dic = new Dictionary<string, string>();
            for (var j = 0; j < headers.Length; j++)
            {
                dic[headers[j]] = strings[j];
            }
            if (strings.Length > headers.Length) //process name has space?
            {
                for (var j = headers.Length; j < strings.Length; j++)
                {
                    dic[headers[headers.Length - 1]] += " " + strings[j];
                }
            }
            process.Add(dic);
        }
    }
