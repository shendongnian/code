    const string FILENAME = @"TrajectoryGen\obstacleList.xml";
    string path = Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location);
    string filepath;
    do
    {
        path = Path.GetDirectoryName(path);
        //pump
        filepath = String.Format("{0}{1}{2}", path, Path.DirectorySeparatorChar, FILENAME);
    } while (!File.Exists(filepath));
