    public static class FileUtil
    {
        public static void CopyMultiple(string sourceFilePath, params string[] destinationPaths)
        {
            if (string.IsNullOrEmpty(sourceFilePath)) throw new ArgumentException("A source file must be specified.", "sourceFilePath");
            if (destinationPaths == null || destinationPaths.Length == 0) throw new ArgumentException("At least one destination file must be specified.", "destinationPaths");
            Parallel.ForEach(destinationPaths, new ParallelOptions(),
                             destinationPath =>
                                 {
                                     using (var source = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                                     using (var destination = new FileStream(destinationPath, FileMode.Create))
                                     {
                                         var buffer = new byte[1024];
                                         int read;
                                         while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
                                         {
                                             destination.Write(buffer, 0, read);
                                         }
                                     }
                                 });
        }
    }
