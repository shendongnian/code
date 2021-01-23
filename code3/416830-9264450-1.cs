    StringBuilder sb = new StringBuilder();
    foreach (char c in str.ToCharArray()) {
        if (c == '[' || c == ']') {
            sb.Append('[' + c + ']');
        }
        else {
            sb.Append(c);
        }
    }
    string result = sb.ToString();
