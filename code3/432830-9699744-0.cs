    private string addEveryOther(string x)
    {
        //1. Convert string to int, not char to int
        int[] d = x.Select(n => Convert.ToInt32(n.ToString())).ToArray();
        //2. start from second number
        for (int i = 1; i < 10; i++)
        {
            d[i] = d[i] * 2;
            MessageBox.Show(d[i].ToString()); //Display the result? 
            i++;
        }
        string s = d.ToString();
        // And later returning a string:
        StringBuilder g = new StringBuilder();
        foreach (int n in d)
        {
            //3. Convert int to string, not to char
            g.Append(n.ToString());
        }
        return g.ToString();
    }
