    String[] lines = System.IO.File.ReadAllLines(path);
    List<String> result = new List<String>();
    int swapIndex = 5;
    if (swapIndex < lines.Length && swapIndex > 0)
    {
        for (int l = 0; l < lines.Length; l++)
        {
            String thisLine = lines[l];
            if (swapIndex == l + 1) // next line must be swapped with this
            {
                String nextLine = lines[l + 1];
                result.Add(nextLine);
                result.Add(thisLine);
                l++;
            }
            else
            {
                result.Add(thisLine);
            }
        }
    }
    System.IO.File.WriteAllLines(path, result);
