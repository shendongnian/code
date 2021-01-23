    #region
    /// <summary>
    /// Custom Method - Check if 'string' has '.png' or '.PNG' extension.
    /// </summary>
    static bool HasPNGExtension(string filename)
    {
        return Path.GetExtension(filename).Equals(".png", StringComparison.InvariantCultureIgnoreCase)
            || Path.GetExtension(filename).Equals(".PNG", StringComparison.InvariantCultureIgnoreCase);
    }
    #endregion
    private void button1_Click(object sender, EventArgs e)
    {
        //NOTE: I recommend you add path checking first here, added the below as example ONLY.
        string ZIPfileLocationHere = @"C:\Users\Name\Desktop\test.zip";
        string EXTRACTIONLocationHere = @"C:\Users\Name\Desktop";
        //Opens existing zip file.
        ZipStorer zip = ZipStorer.Open(ZIPfileLocationHere, FileAccess.Read);
        //Read all directory contents.
        List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();
        foreach (ZipStorer.ZipFileEntry entry in dir)
        {
            try
            {
                //If the files in the zip are "*.png or *.PNG" extract them.
                string path = Path.Combine(EXTRACTIONLocationHere, (entry.FilenameInZip));
                if (HasPNGExtension(path))
                {
                    //Extract the file.
                    zip.ExtractFile(entry, path);
                }
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Error: The ZIP file is invalid or corrupted");
                continue;
            }
            catch
            {
                MessageBox.Show("Error: An unknown error ocurred while processing the ZIP file.");
                continue;
            }
        }
        zip.Close();
    }
