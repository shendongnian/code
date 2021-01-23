    var fi = new FileInfo(""\\Tests\Results\knowles\project\LU\D15\RUN1\Results.xml"");
    var di = fi.Directory;
    var find = "project";
    di = GetGreatestParent(di, find);
    if (di == null)
    {
        throw new Exception(string.Format("Directory with name '{0}' was not found.", find));
    }
    public DirectoryInfo GetGreatestParent(DirectoryInfo Dir, string Find)
    {
        if (Dir != null)
        {
            var p = GetGreatestParent(Dir.Parent, string Find);
            if (p != null)
            {
                return p;
            }
            else if (Dir.Name.ToLower() == Find.ToLower())
            {
                return Dir;
            }
        }
        return null;
    }
    
