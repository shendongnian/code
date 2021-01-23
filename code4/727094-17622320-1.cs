    string[] ls = line.Split('\t');
    StringBuilder sb = new StringBuilder();
    sb.Append(float.Parse(ls[0]));
    sb.Append(' ');
    sb.Append(int.Parse(ls[1])) * 10 + 1);
    for (int i = 2; i < ls.Length; i++)
    {
        sb.Append(' ');
        sb.Append(int.Parse(ls[i]));    }
    }
    var sout = sb.ToString();
    // lock and write
    lock (sw)
    {
        sw.Write(sout);
    }
