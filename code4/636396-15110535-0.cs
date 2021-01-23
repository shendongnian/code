    string id = "1,2,3,4,5";
    string value = "abc,pqr,xyz,mno,qwe";
    var ids = id.Split(new char[] { ',' });
    var values = value.Split(new char[] { ',' });
    Dictionary<string, string> listDict = new Dictionary<string, string>();
    for (int i = 0; i < ids.Length; i++)
    {
        listDict.Add(ids[i], values[i]);
    }
    gridView1.DataSource = listDict;
    gridView1.DataBind();
