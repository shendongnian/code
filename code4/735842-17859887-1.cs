    private static bool TryParseMultiformat(string s, out DateTime res) {
        // Check all parsers in turn, looking for one returning success
        foreach (var p in DateParsers) {
            var tmp = p(s);
            if (tmp.Item2) {
                res = tmp.Item1;
                return true;
            }
        }
        res = DateTime.MinValue;
        return false;
    }
    
