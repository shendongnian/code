class Program
{
    static void Main(string[] args)
    {
        var zipFilename = @"c:\temp\data.zip";
        var client = new AmazonS3Client();
        S3DirectoryInfo rootDir = new S3DirectoryInfo(client, "norm-ziptest");
        using (var zip = new ZipFile())
        {
            zip.Name = zipFilename;
            addFiles(zip, rootDir, "");
        }
        // Move local zip file to S3
        var fileInfo = rootDir.GetFile("data.zip");
        fileInfo.MoveFromLocal(zipFilename);
    }
    static void addFiles(ZipFile zip, S3DirectoryInfo dirInfo, string archiveDirectory)
    {
        foreach (var childDirs in dirInfo.GetDirectories())
        {
            var entry = zip.AddDirectoryByName(childDirs.Name);
            addFiles(zip, childDirs, archiveDirectory + entry.FileName);
        }
        foreach (var file in dirInfo.GetFiles())
        {
            using (var stream = file.OpenRead())
            {                    
                zip.AddEntry(archiveDirectory + file.Name, stream);
                // Save after adding the file because to force the 
                // immediate read from the S3 Stream since 
                // we don't want to keep that stream open.
                zip.Save(); 
            }
        }
    }
}
