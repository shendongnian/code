    namespace ConsoleApplication1
    {
        public static class testClass
        {
            public static string BoolToYesOrNo(this bool text, out string outAsHtmlName)
            {
                string[] choices = { "Yes", "No", "N/A" };
                switch (text)
                {
                    case true: outAsHtmlName = choices[0]; return choices[0];
                    case false: outAsHtmlName = choices[1]; return choices[1];
                    default: outAsHtmlName = choices[2]; return choices[2];
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                bool b = true;
                string result = string.Empty;
                string retval = b.BoolToYesOrNo(out result);
                Console.WriteLine(retval + ", " + result); //output: "Yes, Yes";
            }
        }
    }
