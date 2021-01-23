    var cols = doc.DocumentNode.SelectNodes("//table[@id='table2']//tr//td");
    for (int ii = 0; ii < cols.Count; ii=ii+2)
    {
        string name = cols[ii].InnerText.Trim();
        int age = int.Parse(cols[ii+1].InnerText.Split(' ')[1]);
    }
