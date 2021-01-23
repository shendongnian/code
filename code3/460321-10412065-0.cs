    String[] lines = System.IO.File.ReadAllLines(path);
    List<String> result = new List<String>();
    for (int l = 0; l < lines.Length; l++)
    {
        String thisLine = lines[l];
        String nextLine = lines.Length > l+1 ? lines[l + 1] : null;
        if (nextLine == null)
        {
            result.Add(thisLine);
        }
        else
        {
            result.Add(nextLine);
            result.Add(thisLine);
            l++;
        }
    }
    System.IO.File.WriteAllLines(path, result);
