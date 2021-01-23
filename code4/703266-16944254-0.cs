    List<string> filelist = new List<string>() { "text1.txt", "text2.txt" };
    List<Tuple<int, int, List<double>>> dataList = new List<Tuple<int, int, List<double>>>();
    foreach (var file in filelist)
    {
        string line;
        using (TextReader tr = new StreamReader(file))
        {
            tr.ReadLine();  //skip header
            while ((line = tr.ReadLine()) != null)
            {
                var tokens = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int longitude = int.Parse(tokens[0]);
                int latitude = int.Parse(tokens[1]);
                double value = double.Parse(tokens[2], CultureInfo.InvariantCulture);
                Tuple<int, int, List<double>> t = dataList.Where(x => (int)x.Item1 == longitude && (int)x.Item2 == latitude).FirstOrDefault();
                if (t == null)
                {
                    dataList.Add(new Tuple<int, int, List<double>>(longitude, latitude, new List<double>() { value }));
                }
                else
                {
                    t.Item3.Add(value);
                }
            }
        }
    }
    using (TextWriter tw = new StreamWriter("output.txt"))
    {
        foreach (var t in dataList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("{0}, {1}, ", t.Item1, t.Item2));
            foreach (var value in t.Item3)
            {
                sb.Append(String.Format("{0}, ", value));
            }
            tw.WriteLine(sb.ToString());
        }
    }
