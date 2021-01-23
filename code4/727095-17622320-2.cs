    sr.ProcessParalel(line => 
    { 
        string[] ls = line.Split('\t');
        lock (sw)
        {
            sw.Write(float.Parse(ls[0]));
            sw.Write(int.Parse(ls[1]) * 10 + 1);
            for (int i = 2; i < ls.Length; i++)
            {
                sw.Write(int.Parse(ls[1]));
            }
        }
     });
