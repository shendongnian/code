    internal sealed class IOHelper
    {
        /// <summary>
        /// get list of files described in csproj
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<string> GetFilesInCSPROJ(string filename)
        {
            var list = new List<string>();
            var lines = File.ReadLines(filename);
            foreach (string line in lines)
            {
                if (line.Contains("<Content Include="))
                    list.Add(Regex.Matches(line, "(?:[^\"]+|\\.)*")[2].Value);
            }
            return list;
        }
    }
