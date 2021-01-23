    public static int GetDirectorySize(string folderPath,int userinput = 0)
    {
        double threshold = userinput == 0 ? 500 : userinput;
        DirectoryInfo di = new DirectoryInfo(folderPath);
        double temp = (di.EnumerateFiles("*", SearchOption.AllDirectories).TakeWhile(fl => (fl.Length / 1024f) / 1024f < threshold).Sum(fi => fi.Length) / 1024f) / 1024f;
        temp = Math.Round(temp, 2);
        if (temp > threshold)
        {
            return -1;
        }
        else
        {
            return 1;
        }
        // or  return temp > threshold ? -1 : 1;
    }
