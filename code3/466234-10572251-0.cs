    string[] results = theserows.Trim().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries); ;
    int count = 0;
    resultSet = new System.Collections.Specialized.NameValueCollection[results.Length];
    foreach (string s in results)
    {
        resultSet[count] = new System.Collections.Specialized.NameValueCollection();
        string[] result = s.Trim().Split(new string[] { ","}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string col in result)
        {
            string[] kv = col.Split('=');
            resultSet[count].Add(kv[0], kv[1]);
        }
        count++;
    }
