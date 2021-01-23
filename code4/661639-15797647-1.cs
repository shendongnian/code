    public struct Version {
        public readonly string Text;
        Version(string text) {
            Text = text;
        }
        public static readonly Version Version1 = new Version("Version1");
        public static readonly Version Version2 = new Version("Version2");
    }
