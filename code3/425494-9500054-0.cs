    static class RsrcUtil {
        static string GetResourceText(string pattern) {
            string result = string.Empty;
            Assembly thisAssembly = typeof(RsrcUtil).Assembly;
            string rsrcName = thisAssembly.GetManifestResourceNames()
                             .FirstOrDefault(x => Regex.IsMatch(x, pattern));
            if (!string.IsNullOrEmpty(rsrcName)) {
                using (Stream stream = thisAssembly.GetManifestResourceStream(rsrcName)) {
                    result = new StreamReader(stream).ReadToEnd();
                }
            }
            return result;
        }
    }
