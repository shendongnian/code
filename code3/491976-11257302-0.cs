    int counter = 0;
    List<string> qs = null;
    private void LoadQs()
    {
        qs = new List<string>();
        qs.Add("aaa");
        qs.Add("bbb");
        qs.Add("ccc");
    }
    private string GetQ(bool increase)
    {
        if (increase)
            counter++;
        else
            counter--;
        if (counter >= qs.Count)
            counter = 0;
        else if (counter <= 0)
            counter = qs.Count;
        string q = qs[counter];
        return q;
    }
