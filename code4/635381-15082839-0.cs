    public void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        try
        {
            //check if the target directory exists
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }
            //copy all the files into the new directory
            // Modified from here
                FileInfo fileInfo = source.GetFiles().OrderByDescending(f => f.CreationTime).FirstOrDefault();
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fileInfo.Name);
                  fileInfo.CopyTo(Path.Combine(target.ToString(), fileInfo.Name), true);
            //ends here
            Console.WriteLine("Success");
        }
        catch (IOException ie)
        {
            Console.WriteLine(ie.Message);
        }
    }
