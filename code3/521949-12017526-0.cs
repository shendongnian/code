    List<string> items = new List<string>();
    items.Add("string1");
    items.Add("string2");
    items.Add("string3");
    string AllItems = "";
    foreach (string item in items)
    {
        AllItems += string.Format("\"{0}\",",item);
    }
    AllItems = AllItems.TrimEnd(',');
    string YourSQLQuery = string.Format("SELECT Column1 FROM Table1 WHERE Column1 IN ({0})", AllItems);
    MessageBox.Show(YourSQLQuery);
