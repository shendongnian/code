    void RecursiveApproach(char[] possibilities, string cur)
    {
    	if (cur.Length == c.Length)
    	{
    		listBox1.Items.Add(cur);
    		return;
    	}
    	for (int i = 0; i < possibilities.Length; i++)
    	{
    		RecursiveApproach(possibilities, cur + possibilities[i]);
    	}
    }
    // Usage
    RecursiveApproach(possibilities, "");
