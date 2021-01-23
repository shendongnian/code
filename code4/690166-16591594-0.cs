    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SandboxConoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int rowCount = 2;
                const int columnCount = 12;
                int minCount = 1;
                int maxCount = 1;
                var sourceArray = new String[rowCount, columnCount]{
                        {"ab","ab","ab","FREE","me","me","me","FREE","mo","mo","FREE","FREE"},
                        {"so","so","FREE","no","no","FREE","to","to","to","FREE","do","do"}
                           };
    
                var destinationArray = new String[rowCount, columnCount];
    
                //Print Source Array
                PrintArrayData(sourceArray, rowCount, columnCount);
                Console.WriteLine("\n\n");
    
                //Data Structures that store data row wise.
                var sourceRowData = new Dictionary<int,List<StringCount>>();
                var destinationRowData = new Dictionary<int, List<StringCount>>();
    
                //Make sourceArray more consumable. Put it into sourceRowData. See Initialize Documentation 
                Initialize(sourceArray, rowCount, columnCount, ref maxCount, sourceRowData);
    
                //Data Structure that stores data by count (Occurences)
                var countIndexDictionary = new Dictionary<int, List<StringCount>>();
                for (int index = minCount; index <= maxCount; index++)
                {
                    countIndexDictionary.Add(index, GetDataMatchingCount(index, sourceRowData));             
                }
    
    
                //Create Destination Row Data
                var random = new Random();
                for (int row = 0; row < rowCount; row++)
                {
                    var destinationList = new List<StringCount>();
    
                    //Count List contains the order of number of within a row. for source row 0 : 3,1,3,1,2,2
                    var countList = sourceRowData[row].Select(p => p.count);
    
                    //Randomize this order.
                    var randomizedCountList = countList.OrderBy(x => random.Next()).ToList();
                    foreach (var value in randomizedCountList)
                    {
                        //For each number (count) on the list select a random element of the same count.
                        int indextoGet = random.Next(0,countIndexDictionary[value].Count - 1);
                        
                        //Add it to the destination List
                        destinationList.Add(countIndexDictionary[value][indextoGet]);
    
                        //Rempve from that string from global count list
                        countIndexDictionary[value].RemoveAt(indextoGet);
                    }
                    destinationRowData.Add(row, destinationList);
                }
    
                //Create Destination Array from Destination Row Data            
                for (int row = 0; row < rowCount; row++)
                {
                    int rowDataIndex = 0;
                    int value = 1;
                    for (int column = 0; column < columnCount; column++)
                    {
                        if (destinationRowData[row][rowDataIndex].count >= value)
                            value++;
               
                        destinationArray[row, column] = destinationRowData[row][rowDataIndex].value;
                        if (value > destinationRowData[row][rowDataIndex].count)
                        {
                            value = 1;
                            rowDataIndex++;
                        }
                    }
                }
    
                //Print Destination Array
                PrintArrayData(destinationArray, rowCount, columnCount);
            }
    
            /// <summary>
            /// Initializes Source Array and Massages data into a more consumable form
            /// Input :{"ab","ab","ab","FREE","me","me","me","FREE","mo","mo","FREE","FREE"},
            ///         {"so","so","FREE","no","no","FREE","to","to","to","FREE","do","do"}
            ///         
            /// Output : 0, {{ab,3},{FREE,1},{me,3},{FREE,1},{mo,2},{FREE,2}}
            ///          1, {{so,2},{FREE,1},{no,2},{FREE,1},{to,3},{FREE,1},{do,2}}
            /// </summary>
            /// <param name="sourceArray">Source Array</param>
            /// <param name="rowCount">Row Count</param>
            /// <param name="columnCount">Column Count</param>
            /// <param name="maxCount">Max Count of any String</param>
            /// <param name="sourceRowData"></param>
            public static void Initialize(string[,] sourceArray, int rowCount, int columnCount, ref int maxCount, Dictionary<int, List<StringCount>> sourceRowData)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    var list = new List<StringCount>();
                    for (int column = 0; column < columnCount; column++)
                    {
                        if (list.FirstOrDefault(p => p.value == sourceArray[row, column]) == null)
                            list.Add(new StringCount(sourceArray[row, column], 1));
                        else
                        {
                            var data = list.LastOrDefault(p => p.value == sourceArray[row, column]);
                            var currentValue = sourceArray[row, column];
                            var previousValue = sourceArray[row, column - 1];
    
                            if (previousValue == currentValue)
                                data.count++;
                            else
                                list.Add(new StringCount(sourceArray[row, column], 1));
    
                            if (data.count > maxCount)
                                maxCount = data.count;
                        }
                    }
                    sourceRowData.Add(row, list);
                }
            }
    
            /// <summary>
            /// Gets List of words with similar number of occurences.
            /// input : 2
            ///         0, {{ab,3},{FREE,1},{me,3},{FREE,1},{mo,2},{FREE,2}}
            ///         1, {{so,2},{FREE,1},{no,2},{FREE,1},{to,3},{FREE,1},{do,2}}
            /// 
            /// 
            /// output : 2,{{mo,2},{FREE,2},{so,2},{no,2},{do,2}} - Not necessarily in that order.
            /// </summary>
            /// <param name="count">Occurance Count</param>
            /// <param name="rowData">Source Row Data</param>
            /// <returns></returns>
            public static List<StringCount> GetDataMatchingCount(int count, Dictionary<int, List<StringCount>> rowData)
            {
                var stringCountList = new List<StringCount>();
                var random = new Random();
                var rowList = rowData.Where(p => p.Value.FirstOrDefault(q => q.count == count) != null).OrderBy(x => random.Next());
                foreach (var row in rowList)
                {
                    stringCountList.AddRange(row.Value.Where(p => p.count == count).Reverse());
                }
                return stringCountList;
            }
    
            /// <summary>
            /// Prints Arrays
            /// </summary>
            /// <param name="data"></param>
            /// <param name="rowCount"></param>
            /// <param name="columnCount"></param>
            public static void PrintArrayData(string[,] data,int rowCount,int columnCount) 
            {
                for (int row = 0; row < rowCount; row++)
                {
                    for (int column = 0; column < columnCount; column++)
                    {
                        Console.Write(data[row, column] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    
        public class StringCount
        {
            /// <summary>
            /// Value of String
            /// </summary>
            public string value { get; set; }
    
            /// <summary>
            /// Count of The String
            /// </summary>
            public int count { get; set; }
    
            public StringCount(string _stringValue, int _count)
            {
                value = _stringValue;
                count = _count;
            }
        }
    }
