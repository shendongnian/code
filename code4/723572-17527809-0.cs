    int length3 = CheckBoxList4.Items.Count;
    int count = 0;         
    for (int i = 0; i < length3; i++)
    {
        BooleanQuery finalQuery1 = (BooleanQuery)Session["Luc_Query"];
        finalQuery1 = finalQuery1.Clone();
        var query1 = new QueryParser("Industry", analyzer).Parse(CheckBoxList4.Items[i].Text);
        finalQuery1.Add(query1, BooleanClause.Occur.MUST);                
        hits = searcher.Search(finalQuery1);
        count = hits.Length();
        CheckBoxList4.Items[i].Text = CheckBoxList4.Items[i].Text + " " + count.ToString() ;
    }
