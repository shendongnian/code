    var top = sshClient.RunCommand("top -n1b").Result;
    var line = top.Split('\n');
    var lineNumOfBlank = Array.IndexOf(line, "");
    var headers = line[lineNumOfBlank + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    var process = new List<Dictionary<string, string>>();
    for (var i = lineNumOfBlank + 2; i < line.Length - 1; i++)
    {
        var li = line[i];
        var strings = li.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var dic = new Dictionary<string, string>();
        for (var j = 0; j < headers.Length; j++)
        {
            dic[headers[j]] = strings[j];
            process.Add(dic);
        }
        if (strings.Length > headers.Length) //process name has space?
        {
            for (var j = headers.Length; j < strings.Length; j++)
            {
                dic[headers[headers.Length - 1]] += " " + strings[j];
            }
        }
    }
