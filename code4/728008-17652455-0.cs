    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    StringBuilder sb = new StringBuilder();
    
    foreach (var item in dictionary)
    {
        sb.AppendFormat("{0} - {1}{2}", item.Key, item.Value, Environment.NewLine);
    }
    
    string result = sb.ToString();
    MessageBox.Show(result);
