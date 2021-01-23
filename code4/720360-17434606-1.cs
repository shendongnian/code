    var arr = new List<double>();
    var lines = File.ReadAllLines(Application.StartupPath+"\\City.txt");
    foreach (var l in lines)
    {
        arr.Add(Convert.ToDouble(l));
    }
    return arr.ToArray();
