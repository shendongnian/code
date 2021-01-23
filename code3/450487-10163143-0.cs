    public class MyClass {
        public string First {get; private set;}
        public string Last {get; private set;}
        public MyClass(string first, string last) {
            First = first;
            Last = last;
        }
        public static bool Parse(string s, out MyClass res) {
            res = null;
            if (s == null) return false;
            var tokens = s.Split(new[] {';'});
            if (tokens.Length != 2) return false;
            res = new MyClass(tokens[0], tokens[1]);
            return true;
        }
    }
