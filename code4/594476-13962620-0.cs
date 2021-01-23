    namespace ConsoleApplication1
    {
        using System;
        using System.Text.RegularExpressions;
    
        class Program
        {
            static void Main(string[] args)
            {
                // This is the test string.
                const string testString = "Test& <b>bold</b> <i>italic</i> <<Tag index=\"0\" />";
    
                // Do a regular expression search and replace. We're looking for a complete tag (which will be ignored) or
                // a character that needs escaping.
                string result = Regex.Replace(testString, @"(?'Tag'\<{1}[^\>\<]*[\>]{1})|(?'Special'[\<\>\""\'\&])", (match) =>
                    {
                        // If a special (escapable) character was found, replace it.
                        if (match.Groups["Special"].Success)
                        {
                            switch (match.Groups["Special"].Value)
                            {
                                case "<":
                                    return "&lt;";
                                case ">":
                                    return "&gt;";
                                case "\"":
                                    return "&quot;";
                                case "\'":
                                    return "&apos;";
                                case "&":
                                    return "&amp;";
                                default:
                                    return match.Groups["Special"].Value;
                            }
                        }
    
                        // Otherwise, just return what was found.
                        return match.Value;
                    });
    
                // Show the result.
                Console.WriteLine("Test String: " + testString);
                Console.WriteLine("Result     : " + result);
                Console.ReadKey();
            }
        }
    }
