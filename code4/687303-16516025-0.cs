    using Ionic.Zip;
    ......
    
    private void BackupToZip(string sourceDBName, string destZipFile, string password)
    {
        using (ZipFile zipF = new ZipFile(destZipFile))
        {
            if (bkpPass.Length > 0) zip.Password = password;
            ZipEntry ze = zip.UpdateFile(sourceDbName, string.Empty);
            ze.Comment = "Working copy stored in date: " + DateTime.Today.ToShortDateString();
            zipF.Comment = "This zip archive has been created by ......";
            zipF.Save();
        }
    }
