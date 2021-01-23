    public static void SayHello()
        {
            Utility.Wrap(() =>
                {
                    SayHello(" world ");
                });
        }
        public static void SayHello(string name)
        {
            Utility.Wrap(() =>
            {
                Console.WriteLine("Hello {0}", name);
            }, name);
        }
        public static int GetCount(string s)
        {
            return Utility.Wrap(() =>
            {
                return string.IsNullOrEmpty(s) ? 0 : s.Length;
            }, s);
        }
