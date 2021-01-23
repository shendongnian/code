    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace ConsoleApplication5
    {
        static class Program
        {
            static void Main(string[] args)
            {
                string password = "1234567890";
    
                string username = "125689";
                string realName = "890";
    
                bool usernameOk = !username.AllPartsOfLength(3)
                    .Any(part => password.Contains(part));
                bool realNameOk = !realName.AllPartsOfLength(3)
                    .Any(part => password.Contains(part));
            }
    
            public static IEnumerable<string> AllPartsOfLength(this string value, int length)
            {
                for (int startPos = 0; startPos <= value.Length - length; startPos++)
                {
                    yield return value.Substring(startPos, length);
                }
                yield break;
            }
        }
    }
