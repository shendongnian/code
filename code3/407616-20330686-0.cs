    public void SortLines(object sender, EventArgs e)
    {
        string[] lines = rtb.Lines;
        Array.Sort(lines, delegate(string str1, string str2)
        {
              return str1.CompareTo(str2);
        });
        rtb.Lines = lines;
    }
