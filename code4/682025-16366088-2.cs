    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
    
                Result result1 = new Result
                                     {
                                         arrival_date = new DateTime(2013, 05, 05),
                                         block = new Result.Block { block_id = 80884788 },
                                         id = 230802
                                     };
                Result result2 = new Result
                                     {
                                         arrival_date = new DateTime(2013, 05, 05),
                                         block = new Result.Block { block_id = 419097 },
                                         id = 98121
                                     };
                Results results = new Results { result = new Result[2] };
                results.result[0] = result1;
                results.result[1] = result2;
    
                WriteSettingsAsXml("D:\\test.xml", typeof(Results), results, true);
    
                Results gA = (Results)ReadSettingsFromXml("D:\\test.xml", typeof(Results));
            }
