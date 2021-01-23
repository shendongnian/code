    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    public static async Task<bool> ZipFileHelper(IFolder folderForZipping, IFolder folderForZipFile, string zipFileName)
    {
        if (folderForZipping == null || folderForZipFile == null
            || string.IsNullOrEmpty(zipFileName))
        {
            throw new ArgumentException("Invalid argument...");
        }
        IFile zipFile = await folderForZipFile.CreateFileAsync(zipFileName, CreationCollisionOption.ReplaceExisting);
        // Create zip archive to access compressed files in memory stream
        using (MemoryStream zipStream = new MemoryStream())
        {
            using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                await ZipSubFolders(folderForZipping, zip, "");
            }
            zipStream.Position = 0;
            using (Stream s = await zipFile.OpenAsync(FileAccess.ReadAndWrite))
            {
                zipStream.CopyTo(s);
            }
        }
        return true;
    }
    //Create zip file entry for folder and subfolders("sub/1.txt")
    private static async Task ZipSubFolders(IFolder folder, ZipArchive zip, string dir)
    {
        if (folder == null || zip == null)
            return;
        var files = await folder.GetFilesAsync();
        var en = files.GetEnumerator();
        while (en.MoveNext())
        {
            var file = en.Current;
            var entry = zip.CreateEntryFromFile(file.Path, dir + file.Name);                
        }
        var folders = await folder.GetFoldersAsync();
        var fEn = folders.GetEnumerator();
        while (fEn.MoveNext())
        {
            await ZipSubFolders(fEn.Current, zip, dir + fEn.Current.Name + "/");
        }
    }
