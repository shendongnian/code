    StringBuilder sb = new StringBuilder();
    var words = textBox1.Text.Split(new char[] { ' ' });
    foreach (var w in words)
    {
        if (string.IsNullOrEmpty(w))
        {
            sb.Append(w);
            continue;
        }
        // do something with w
        sb.Append(w);
    }
