    private List<String> DirSearch(string sDir)
    {
        List<String> files = new List<String>();
        try
        {
            foreach (string f in Directory.GetFiles(sDir))
            {
                files.Add(f);
            }
            foreach (string d in Directory.GetDirectories(sDir))
            {
                files.AddRange(DirSearch(d));
            }
        }
        catch (System.Exception excpt)
        {
            MessageBox.Show(excpt.Message);
        }
        return files;
    }
