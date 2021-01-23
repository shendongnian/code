    //     FileShare.Write Allows subsequent opening of the file for writing. If this flag is not specified,
    //     any request to open the file for writing (by this process or another process)
    //     will fail until the file is closed. However, even if this flag is specified,
    //     additional permissions might still be needed to access the file.
    using (FileStream fstream = new FileStream(imgPath, FileMode.Create, FileAccess.Write, FileShare.Write))
    {
        encoder.Save(fstream);
        fstream.Close();
    }
