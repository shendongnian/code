    string getTruncated(string s) {
        int startIdx = -1;
        for (int i = 0; i < s.Length; ++i) {
            if (Char.IsLetter(s[i])) {
                startIdx = i;
                break;
            }
        }
        int endIdx = s.IndexOf('.');
        if (startIdx != -1) {
            if (endIdx != -1) {
                return s.Substring(startIdx, endIdx);
            } else {
                return s.Substring(startIdx);
            }
        } else {
            throw new ArgumentException();
        }
    }
