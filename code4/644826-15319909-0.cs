    private List<MyValues> Read(string fileName)
    {
        List<MyValues> list = new List<MyValues>();
        string[] line = new string[] { };
        using (StreamReader sr = new StreamReader(fileName))
        {
            while (sr.Peek() > -1)
            {
                line = sr.ReadLine().Trim().Split(' ');
                MyValues val = new MyValues();
                val.Id = Convert.ToInt32(line.ElementAt(0));
                for (int n = 1; n < line.Count(); n++)
                {
                    val.Values.Add(Convert.ToDouble(line[n]));
                }
                list.Add(val);
            }
        }
        return list;
    }
    class MyValues
    {
        public int Id = 0;
        public List<double> Values = new List<double>();
    }
