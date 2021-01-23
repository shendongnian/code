    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            	const string example = "PrintFileURL(\"13572_IndividualInformationReportDelta_2012-06-29_033352.zip\",\"13572_IndividualInformationReportDelta_2012-06-29_033352.zip\",0,\"53147\",\"Jun 29 3:33\",\"/icons/default.gif\")";
    			Console.WriteLine(example);
    
            	const string pattern = "\\\"([a-zA-Z0-9\\-_]*?\\..*?)\\\"";
            	var regex = new Regex(pattern);
    			var result = regex.Matches(example);
            	foreach (Match item in result)
            	{
            		Console.WriteLine(item.Groups[1]);
            	}
            }
        }
    }
