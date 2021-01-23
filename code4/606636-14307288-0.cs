    public void StartProcessesByPriority(Dictionary<String, ProcessPriorityClass> values)
    {
        List<KeyValuePair<String, ProcessPriorityClass>> valuesList = values.ToList();
    
        valuesList.Sort
        (
            delegate(KeyValuePair<String, ProcessPriorityClass> left, KeyValuePair<String, ProcessPriorityClass> right)
            {
                return left.Value.CompareTo(right.Value);
            }
        );
    
        foreach (KeyValuePair<String, ProcessPriorityClass> pair in valuesList)
        {
            Process process = new Process();
            process.StartInfo.FileName = pair.Key;
            process.Start();
    
    	    process.PriorityClass = pair.Value;
    
    	    process.WaitForExit();
        }
    }
