    private static int toint(string s) {
        int res = 0;
        foreach (var c in s) {
            res = 10*res + (c - '0');
        }
        return res;
    }
    static void Main() {
        var s = DateTime.Now;
        for (int i = 0 ; i != 10000000 ; i++) {
            if (Convert.ToInt32("112345678") == 0) break;
        }
        var m = DateTime.Now;
        for (int i = 0; i != 10000000; i++) {
            if (toint("112345678") == 0) break;
        }
        Console.WriteLine("{0} {1}", DateTime.Now-m, m-s);
    }
