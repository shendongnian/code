    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication3
    {
        class StringColIndex
        {
            public int ColIndex { get; set; }
            public List<string> StringValues {get;set;}
        }
        class Program
        {
            static void Main(string[] args)
            {
                var StringRepresentationAsInt = new List<StringColIndex>();
                List<string> rawDataList = new List<string>();
                List<string> rawDataWithStringsAsIdsList = new List<string>();
                rawDataList.Add("AUDI;40912.2;m");rawDataList.Add("VW;3332;f ");
                rawDataList.Add("AUDI;1234.99;m");rawDataList.Add("DACIA;0;m");
                rawDataList.Add("AUDI;12354.2;m");rawDataList.Add("AUDI;123;m");
                rawDataList.Add("VW;21321.2;f ");
                foreach(var rawData in rawDataList)
                {
                    var split = rawData.Split(';');
                    var line = string.Empty;
                    for(int i= 0; i < split.Length; i++)
                    {
                        double outValue;
                        var isNumberic = Double.TryParse(split[i], out outValue);
                        var txt = split[i];
                        if (!isNumberic)
                        {
                            if(StringRepresentationAsInt
                                .Where(x => x.ColIndex == i).Count() == 0)
                            {
                                StringRepresentationAsInt.Add(
                                    new StringColIndex { ColIndex = i,
                                        StringValues = new List<string> { txt } });
                            }
                            var obj = StringRepresentationAsInt
                                .First(x => x.ColIndex == i);
                            if (!obj.StringValues.Contains(txt)){
                                obj.StringValues.Add(txt);
                            }
                            line += (string.IsNullOrEmpty(line) ? 
                                string.Empty : 
                                ("," + (obj.StringValues.IndexOf(txt) + 1).ToString()));
                        }
                        else
                        {
                            line += "," + split[i];
                        }
                    }
                    rawDataWithStringsAsIdsList.Add(line);
                }
                rawDataWithStringsAsIdsList.ForEach(x => Console.WriteLine(x));
                Console.ReadLine();
                /*
                Desired output:
                1;40912.2;0 
                2;3332;1 
                1;1234.99;0 
                3;0;0 
                1;12354.2;0 
                1;123;0 
                2;21321.2;1 
                */
            }
        }
    }
