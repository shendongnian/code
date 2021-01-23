    private static void OperateOnSourceFiles(string source, string targetDir)
    {
        foreach (var file in Directory.GetFiles(source))
        {
            OverWrite(targetDir, file);
        }
        List<string> subfolders = Directory.GetDirectories(source).ToList();
        foreach (var subfolder in subfolders)
        {
            OperateOnSourceFiles(subfolder, targetDir);
        }
    }
