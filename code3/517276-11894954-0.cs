    int pointer = 0;
    int index = 0;
    string keyword = "txtComKeyword1";
    while (true)
    {
        index = richComResults.Text.IndexOf(keyword, pointer);
        //if keyword not found
        if (index == -1)
        {
            break;
        }
        richComResults.Select(index, keyword.Length);
        richComResults.SelectionFont = new System.Drawing.Font(richComResults.Font, FontStyle.Bold);
        pointer = index + keyword.Length;
    }
