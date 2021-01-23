    internal static class RsrcUtil {
        private static Assembly _thisAssembly;
        private static Assembly thisAssembly {
            get {
                if (_thisAssembly == null) { _thisAssembly = typeof(RsrcUtil).Assembly; }
                return _thisAssembly;
            }
        }
        internal static string GetNlogConfig(string prefix) {
            return GetResourceText(@"Some\Folder\" + prefix + ".nlog.config");
        }
        internal static string FindResource(string pattern) {
            return thisAssembly.GetManifestResourceNames()
                   .FirstOrDefault(x => Regex.IsMatch(x, pattern));
        }
        internal static string GetResourceText(string resourceName) {
            string result = string.Empty;
            if (thisAssembly.GetManifestResourceInfo(resourceName) != null) {
                using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName)) {
                    result = new StreamReader(stream).ReadToEnd();
                }
            }
            return result;
        }
    }
