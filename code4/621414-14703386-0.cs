    /// <summary>
    /// Class for getting environment information
    /// </summary>
    public static class EnvironmentInfo
    {
        /// <summary>
        /// Gets environment information by querying the system
        /// </summary>
        public static IEnumerable<string> GetEnvironmentInfo()
        {
            List<string> results = new List<string>();
            SafeUpdateListOfResultsFromInstrumentation("OS Product: {0}", results, "select * from win32_OperatingSystem", "name");
            SafeUpdateListofResults("OS Version: {0}", results, (() => Environment.OSVersion.ToString()));
            
            return results;
        }
        private static void SafeUpdateListofResults(string format, List<string> results, Func<string> del)
        {
            try
            {
                string str = del.Invoke();
                results.Add(string.Format(format, str));
            }
            catch (Exception)
            {
                //Swallow exception - can't get diagnostic info!
            }
        }
        private static void SafeUpdateListOfResultsFromInstrumentation(string format, List<string> results, string query, string index)
        {
            try
            {
                WqlObjectQuery objectQuery = new WqlObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(objectQuery);
                string name, value;
                foreach (ManagementObject managementObject in searcher.Get())
                {
                    name = managementObject[index].ToString();
                    string[] split1 = name.Split('|');
                    value = split1[0];
                    results.Add(string.Format(format, value));
                }
            }
            catch (Exception)
            {
                //Swallow exception - can't get diagnostic info!
            }
        }
    }
