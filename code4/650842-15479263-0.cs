    private string MakePath(string subFolder, object obj, int index)
    {
        if(obj.GetType()==typeof(string))
        {
            //copy the strong typed version to here;
            return;
        }
        string dir = System.IO.Path.Combine(_outputDir, subFolder);
        string fileName = string.Format("{0} {1} {2}.xml",
            obj.GetType().Name, _dateTimeSource.Now.ToString(DATE_FORMAT), index.ToString());
        return System.IO.Path.Combine(dir, fileName);
    }
