    using (Package package = ZipPackage.Open(zipFilePath, FileMode.Open, FileAccess.Read))
    {
        foreach (PackagePart part in package.GetParts())
        {
            var target = Path.GetFullPath(Path.Combine(tempFolderPath, part.Uri.OriginalString.TrimStart('/')));
            var targetDir = target.Remove(target.LastIndexOf('\\'));
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            using (Stream source = part.GetStream(FileMode.Open, FileAccess.Read))
            using (Stream targetFileStream = File.OpenWrite(target))
            {
                source.CopyTo(targetFileStream);
            }
        }
    }
