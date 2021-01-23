    using (ZipFile zipDest = ZipFile.Read(myOtherZip))
    {
        foreach (var dir in System.IO.Directory.GetDirectories(outputDirectory))
        {
            zipDest.AddFiles((System.IO.Directory.EnumerateFiles(dir)),false,outputDirectory ); //directory to the root
        }
        zipDest.AddFiles((System.IO.Directory.EnumerateFiles(outputDirectory)),false,""); //This will add the files to the root
        zipDest.Save();
    }
