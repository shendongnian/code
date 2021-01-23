    const string FILENAME = "obstacleList.xml";
    const string FOLDER = "TrajectoryGen";
    string path = Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location);
    do
    {
         path = Path.GetDirectoryName(path);
    } while (!Path.GetFileName(path).Equals(FOLDER, StringComparison.OrdinalIgnoreCase));
    string filepath = String.Format("{0}{1}{2}", path, Path.DirectorySeparatorChar, FILENAME);
    
