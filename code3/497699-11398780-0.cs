    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] strArr = 
                {
                ",SUM(CASE WHEN [Level] IN('4') AND Program = 1 THEN 1 ELSE 0 END) as CNT1",
                ",SUM(CASE WHEN [Level] IN('3') AND Program = 1 THEN 1 ELSE 0 END) as CNT2",
                ",SUM(CASE WHEN [Level] IN('2') AND Program = 1 THEN 1 ELSE 0 END) as CNT3",
                ",SUM(CASE WHEN [Level] IN('1') AND Program = 1 THEN 1 ELSE 0 END) as CNT4",
                ",SUM(CASE WHEN [Level] IN('0') AND Program = 1 THEN 1 ELSE 0 END) as CNT5",
                };
                
                //intellisence didn't like assignment in the foreach loop
                for(int i=0; i<strArr.Length; i++)
                {
                    string cnt = Regex.Match(strArr[i], @"CNT\d+$").Value;
                    strArr[i] = strArr[i].Replace(",", String.Format(",{0} = ",cnt)).Replace(String.Format(" as {0}", cnt), "");
                }
    
                foreach(string str in strArr)
                {
                    Console.WriteLine(str);
                }
    
            }
        }
    }
