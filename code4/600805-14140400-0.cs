    StringBuilder result = new StringBuilder(input.Length);
    foreach (char ch in input) {
        switch (ch) {
            case '*':
            case '^':
                break;
            default:
                result.Append(ch);
                break;
        }
    }
    string s = result.ToString();
