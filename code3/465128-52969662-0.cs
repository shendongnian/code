        private static string Wrap(string v, int size)
        {
            v = v.TrimStart();
            if (v.Length <= size) return v;
            var nextspace = v.LastIndexOf(' ', size);
            if (-1 == nextspace) nextspace = Math.Min(v.Length, size);
            return v.Substring(0, nextspace) + ((nextspace >= v.Length) ? 
            "" : "\n" + Wrap(v.Substring(nextspace), size));
        }
