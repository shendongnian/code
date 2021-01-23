    var result = new Dictionary<string, string>();
    foreach (var fileAssistant in duplicateList)
    {
        if (result.ContainsKey(fileAssistant.ItemNo))
        {
            result[fileAssistant.ItemNo] = string.Format("{0}, {1}", result[fileAssistant.ItemNo], fileAssistant.FileName);
        }
        else
        {
            result.Add(fileAssistant.ItemNo, fileAssistant.FileName);
        }
    }
