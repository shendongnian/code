    public async Task RunServiceTests()
        {
            // Find the list of Test Cases in the running assembly
            // all methods that start with "TC"
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetExportedTypes();
            string testCaseString = "TC";
            Dictionary<long, MethodInfo> dictionary = new Dictionary<long, MethodInfo>();
            long testCaseNumber = 0;
            MethodInfo[] methods = null;
            foreach (Type t in types)
            { if(t.Name == "ServicesTests")
                {
                    methods = t.GetMethods();
                   
                    foreach (MethodInfo method in methods)
                    {
                        Regex regex = new Regex(@"TC\d+");
                        Match match = regex.Match(m.Name);
                        if (match.Success)
                        {
                            simpleLogger.WriteLine("Method Name:  " + method.Name);
                            int pos = -1;
                            string name = method.Name;
                            pos = name.IndexOf("_");
                            int length = pos - 2;
                            testCaseString = name.Substring(2, length);
                            simpleLogger.LogInfo("Test Case Number found: " + testCaseString);
                            testCaseNumber = Convert.ToInt64(testCaseString);
                            if (!dictionary.ContainsKey(testCaseNumber))
                            {
                                dictionary.Add(testCaseNumber, method);
                            }
                        }
                    } // End of methodInfo loop
                    break;
                }
            }
            foreach (KeyValuePair<long, MethodInfo> kvp in dictionary)
            {
                MethodInfo method = kvp.Value;
                Task task = (Task) method.Invoke(Instance, null);
                 await task;
            }
        }
