    private static Dictionary<string, string> ResolveArguments(string[] args)
    {
        if (args == null)
            return null;
        if (args.Length > 1)
        {
            var arguments = new Dictionary<string, string>();
            foreach (string argument in args)
            {
                int idx = argument.IndexOf('=');
                if (idx > 0)
                    arguments[argument.Substring(0, idx)] = argument.Substring(idx+1);
            }
            return arguments;
        }
        return null;
    }
