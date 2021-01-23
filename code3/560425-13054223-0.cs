    void Analyze(ref String InputText, ref Dictionary<string, int> WordFreq)
    {
        string []Words = InputText.Split(' ');
        for (int i = 0; i < Words.Length; i++)
        {
            if (WordFreq.ContainsKey(Words[i]) == false)
                WordFreq.Add(Words[i], 1);
            else
            {
                 WordFreq[Words[i]]++;
            }
        }
    }
    void DoWork()
    {
        string InputText = "free numerology compatibility numerology calculator free free numerology report numerology reading free numerology reading";
        Dictionary<string, int> WordFreq = new Dictionary<string,int>();
        Analyze(ref InputText,ref WordFreq);
        string result = null;
        foreach (KeyValuePair<string, int> pair in WordFreq)
        {
            result += pair.Value + " Instances of " + pair.Key + "\r\n";
        }
        MessageBox.Show(result);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        DoWork();
    }
