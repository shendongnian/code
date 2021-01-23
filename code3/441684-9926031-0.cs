    string test = txtBox.Text;
    StringBuilder sb = new StringBuilder();
    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict["black"] = "white";
    dict["white"] = "black";
    string[] chunks = test.Split(' ');
    foreach (string s in chunks)
    {
      string val;
      if (dict.TryGetValue(s, out val))
      {
        sb.Append(val);
        sb.Append(" ");
      }
      else
      {
        sb.Append(s);
        sb.Append(" ");
      }
    }
    textBox2.Text = sb.ToString().TrimEnd();
