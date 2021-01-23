    // string input = TextBox1.Text;
    List<int> intList = new List<int>();
    foreach (char c in input)
    {
        int i;
        if (Int32.TryParse(c.ToString(), out i))
        {
            intList.Add(i);
        }
    }
