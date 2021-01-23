    double[] GetNumbers(string str)
    {
        double num;
        List<double> l = new List<double>();
        foreach (string s in str.Split(' '))
        {
            bool isNum = double.TryParse(s, out num);
            if (isNum)
            {
                l.Add(num);
            }
        }
        return l.ToArray();
    }
