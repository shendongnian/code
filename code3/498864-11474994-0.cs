        static void Main(string[] args)
        {
            var arguments = new Dictionary<string, string>();
            foreach (string argument in args)
            {
                string[] splitted = argument.Split('=');
                if (splitted.Length == 2)
                {
                    arguments[splitted[0]] = splitted[1];
                }
            }
        }
