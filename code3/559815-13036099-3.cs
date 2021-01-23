    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static string testData = @"{
       'total':3,
       'data':{
          'some...@company.com':[
             {
                'action':'click',
                'timestamp':'2012-10-18 20:55:52',
                'url':'http:\/\/www.someurl.com?ct=t(First_Chimp_Test10_18_2012)',
                'ip':'66.66.666.666'
             },
             {
                'action':'open',
                'timestamp':'2012-10-18 20:55:52',
                'url':null,
                'ip':'66.66.666.666'
             }
          ],
          'anothe...@corporation.com':[
             {
                'action':'open',
                'timestamp':'2012-10-18 20:18:05',
                'url':null,
                'ip':'22.222.222.222'
             },
             {
                'action':'open',
                'timestamp':'2012-10-18 20:18:18',
                'url':null,
                'ip':'22.222.222.222'
             },
             {
                'action':'click',
                'timestamp':'2012-10-18 20:18:18',
                'url':'http:\/\/www.someurl.com?ct=t(First_Chimp_Test10_18_2012)',
                'ip':'22.222.222.222'
             },
             {
                'action':'click',
                'timestamp':'2012-10-18 20:21:57',
                'url':'http:\/\/www.someurl.com?ct=t(First_Chimp_Test10_18_2012)',
                'ip':'22.222.222.222'
             }
          ],
          'thir...@business.com':[
    
          ]
       }
    }";
    
            public class ItemInfo {     
               public string action { get; set; }     
               public string timestamp { get; set; }     
               public string url { get; set; }     
               public string ip { get; set; } 
            }
    
            public class ContainerType {
                public int total;
                public Dictionary<string, ItemInfo[]> data;
            }
            static void Main(string[] args)
            {
                ContainerType container = JsonConvert.DeserializeObject<ContainerType>(testData);
            }
        }
    }
