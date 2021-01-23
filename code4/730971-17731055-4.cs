    public sealed class Output
    {
        private Dictionary<Out, Action<string, Color>> registeredWriters = new Dictionary<Out, Action<string, Color>>();
        public static readonly Output Instance = new Output();
        private void Output() { } // Empty private constructor so another instance cannot be created.
        public void Unregister(Out outType)
        {
            if (registeredWriters.ContainsKey(outType))
                registeredWriters.Remove(outType);
        }
        // Assumes caller will not combine the flags for outType here
        public void Register(Out outType, Action<string, Color> writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (registeredWriters.ContainsKey(outType))
            {
                // You could throw an exception, such as InvalidOperationException if you don't want to 
                // allow a different writer assigned once one has already been.
                registeredWriters[outType] = writer;
            }
            else
            {
                registeredWriters.Add(outType, writer);
            }
        }
        public void WriteLine(Color color, string str, Const.Out output = Const.Out.Debug & Const.Out.Main)
        {
            bool includeDebug = false;
            #if DEBUG
            includeDebug = true;
            #endif
            foreach (var outType in registeredWriters.Keys)
            {
                if (outType == Const.Out.Debug && !includeDebug)
                    continue;
                if (bitmask(output, outType))
                    registeredWriters[outType](str, color);
            }
        }
    }
