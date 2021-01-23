    static class Output
    {
        private static List<Action<string, Color>> RetrieveOutputMechanisms(Const.Out output)
        {
            List<Action<string, Color>> result = new List<string, Color>();
    
        #if DEBUG
            if (bitmask(output, Const.Out.Debug))
                result.Add((s, c) => Console.WriteLine(s, c)); //I want to add Console here, but its static
        #endif
            if (bitmask(output, Const.Out.Main))
                if (Program.mainForm != null)
                    result.Add((s, c) => Program.mainForm.Box.WriteLine(s, c));
            if (bitmask(output, Const.Out.Code))
                if (Program.code!= null)
                    result.Add((s, c) => Program.code.Box.WriteLine(s, c));
            return result;
        }
        public static void WriteLine(Color color, string str, Const.Out output = Const.Out.Debug & Const.Out.Main)
        {
            var writers = RetrieveOutputMechanisms(output);
            foreach (var writer in writers)
                writer(str, color);
        }
    }
