    private static int toint(string s) {
        int res = 0;
        foreach (var c in s) {
            if (Char.IsDigit(c))
                res = 10*res + (c - '0');
        }
        return res;
    }
