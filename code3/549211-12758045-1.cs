    using Ionic.Zip;
    ......
    private void BackupToZip(string sourceDBName, string destZipFile, string password)
    {
        using (ZipFile zip = new ZipFile(destZipFile))
        {
            if (bkpPass.Length > 0) zip.Password = password;
            ZipEntry e = zip.UpdateFile(sourceDbName, string.Empty);
            e.Comment = "Working copy stored in date: " + DateTime.Today.ToShortDateString();
            zip.Comment = "This zip archive has been created by ......";
            zip.Save();
        }
    }
