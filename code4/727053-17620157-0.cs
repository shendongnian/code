        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(textBoxPath.Text);
        System.IO.FileInfo[] fileInformations = dir.GetFiles();  
        for (int i = 0; i <= fileInformations.Length; i++)
        {
            System.IO.File.Move(fileInformations[i].DirectoryName, System.IO.Path.Combine(FileInformation[i].Directory, "File" + i));
        }
