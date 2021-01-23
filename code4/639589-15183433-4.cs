    List<int> column0  = new List<int>(), column1 = new List<int>();
    
    using (Stream stream = File.Open(path, FileMode.Open))
    using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] arr = line.Split(' ');
            column0.Add(Int32.Parse(arr[0]);
            column1.Add(Int32.Parse(arr[1]);
        }
    }
