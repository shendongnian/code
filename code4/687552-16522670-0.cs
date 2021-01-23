    List<TextElement> list = new List<TextElement>();
    for(int i = 0; i < dt.Rows.Count; i++)
    {
        String wholetext = dt.Rows[i][1].ToString() + "--" + dt.Rows[i][1].ToString();
        
        list.Add(new TextElement(wholetext));
     }
     superMarquee1.Elements.AddRange(list.ToArray());
