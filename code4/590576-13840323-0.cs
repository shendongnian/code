    public static class FileInfoExtensions
    {
      public static void MergeFiles(this FileInfo fi, string strOutputPath , params string[] filesToMerge)
      {
        var fiLines = File.ReadAllLines(fi.FullName).ToList();
        fiLines.AddRange(filesToMerge.SelectMany(file => File.ReadAllLines(file)));
        File.WriteAllLines(strOutputPath, fiLines.ToArray());
      }
    }
