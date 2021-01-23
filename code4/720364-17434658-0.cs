    string line;
    List<double> values = new List<double>();
    string path = Path.Combine(Application.StartupPath, "City.txt");
    
    System.IO.StreamReader file = new System.IO.StreamReader(path);
    while((line = file.ReadLine()) != null)
    {
        values.Add(double.Parse(line));
    }
    
    file.Close();
