    using System;
    using System.Text.RegularExpressions;
    class Tester
    {
    	public static void Main()
    	{
    		string s = "Insert into VERSION " + 
    			"(ENTRYID,APPVERSION,PLATFORMVERSION,TIMESTAMPED,USERNAME,SQLSCRIPTNAME,COMMENTS)" +
    			"VALUES(SWS_Version_ID.\"NEXTVAL\",'[3.02.01P20]','[4.1.38orcl]',sysdate,null,null,null);";
    		Match m = (new Regex("^(.*)(\\[.*?\\])(.*?)(\\[.*?\\])(.*)$")).Match(s);
    		//Console.WriteLine("{0},{1}", m.Groups[2].Value, m.Groups[3].Value);
    		string[] parts = {
    				m.Groups[1].Value,
    				m.Groups[2].Value, //[3.02.01P20]
    				m.Groups[3].Value, //','
    				m.Groups[4].Value, //[4.1.38orcl]
    				m.Groups[5].Value //tail
    			};
    		parts[1] = "[NEW_VERSION]";
    		Console.WriteLine(string.Join("",parts));
    	}
    }
