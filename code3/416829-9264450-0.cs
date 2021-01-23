    StringBuilder sb = new StringBuilder();
    foreach (char c in str.ToCharArray()) {
        if (c == '[' || char == ']') {
            sb.Append('[' + c + ']');
        }
        else {
            sb.Append(c);
        }
    }
    string result = sb.ToString();
