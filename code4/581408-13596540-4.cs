    public static List<DataPoint> LoadFromFile (string filename) 
    {
        // The .NET framework has a lot of helper methods
        // be sure to check them out at MSDN
        // Read the contents of the file into a string array
        string[] lines = File.ReadAllLines(filename);
        // Create the result List
        List<DataPoint> result = new List<DataPoint>();
        // Parse the lines
        for (string line in lines)
        {
            string[] bits = line.Split(',');
            
            // We're using our own constructor here
            // Do watch out for invalid files, resulting in out-of-index Exceptions
            DataPoint dataPoint = new DataPoint(bits[0], bits[1], bits[2]);
            result.Add(dataPoint);
        }
        return result;
    }
