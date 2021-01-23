    private void clearRichtextBox()
    {
        StringBuilder sb = new StringBuilder();
    
        foreach (KeyValuePair<string, List<string>> kvp in LocalyKeyWords)
        {
            for (int i = 0; i < kvp.Value.Count(); i++)
            {
                sb.AppendFormat("Url: {0} Localy KeyWord: {1}{2}", kvp.Key,kvp.Value[i],Environment.NewLine);
            }
        }
    
        string viewString = sb.ToString();
        if(viewString != richTextBox2.Text)
        {
             richTextBox2.Text = viewString;
        }
    }
