    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    class ExampleClass
    {
        static void Main(string[] args)
        {
            string example = "<?TAG param1=\"val1\" param2=\"val2\" paramN=\"valN\" /><?TAG param1=\"val1\" param2=\"val2\" paramN=\"valN\"/><?TAG param1=\"val1\" param2=\"val2\" paramN=\"valN\"/>";
    	List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            string[] tokens = Regex.Split(example, "/><\\?TAG|<\\?TAG|/>");
            foreach (string token in tokens) if (token.Length > 0)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                string[] parms = token.Split(' ');
                foreach (string parm in parms) if (parm.Length > 0)
                {
                    string[] keyvalue = Regex.Split(parm, "=\"|\"");
                    parameters.Add(keyvalue[0], keyvalue[1]);
                }
                result.Add(parameters);
            }
    
    	Console.WriteLine("TAGs detected: " + result.Count);
    	foreach (Dictionary<string, string> token in result)
            {
                Console.WriteLine("TAG");
                foreach (KeyValuePair<string, string> kvp in token)
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }
    }
