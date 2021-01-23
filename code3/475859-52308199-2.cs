    Install Nuget package NewtonSoft.Json
    Add reference dll Microsoft.VisualBasic
    
    using System.Linq;
    using Newtonsoft.Json;
    using Microsoft.VisualBasic.FileIO;
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    namespace Project
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                string CSVpath = @"D:\New Folder\information.csv";
                string analyticsData = ReadFile(CSVpath);
            }
    
            private static string ReadFile(string filePath)
            {
                string payload = "";
                try
                {
                    if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath) && Path.GetExtension(filePath).Equals(".csv", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string[] lines = File.ReadAllLines(filePath);
    
                        if (lines != null && lines.Length > 1)
                        {
                            var headers = GetHeaders(lines.First());
                            payload = GetPayload(headers, lines.Skip(1));
                        }
                    }
                }
                catch (Exception exp)
                {
                }
                return payload;
            }
    
            private static IEnumerable<string> GetHeaders(string data)
            {
                IEnumerable<string> headers = null;
    
                if (!string.IsNullOrWhiteSpace(data) && data.Contains(','))
                {
                    headers = GetFields(data).Select(x => x.Replace(" ", ""));
                }
                return headers;
            }
    
            private static string GetPayload(IEnumerable<string> headers, IEnumerable<string> fields)
            {
                string jsonObject = "";
                try
                {
                    var dictionaryList = fields.Select(x => GetField(headers, x));
                    jsonObject = JsonConvert.SerializeObject(dictionaryList);
                }
                catch (Exception ex)
                {
                }
                return jsonObject;
            }
    
            private static Dictionary<string, string> GetField(IEnumerable<string> headers, string fields)
            {
                Dictionary<string, string> dictionary = null;
    
                if (!string.IsNullOrWhiteSpace(fields))
                {
                    var columns = GetFields(fields);
    
                    if (columns != null && headers != null && columns.Count() == headers.Count())
                    {
                        dictionary = headers.Zip(columns, (x, y) => new { x, y }).ToDictionary(item => item.x, item => item.y);
                    }
                }
                return dictionary;
            }
    
            public static IEnumerable<string> GetFields(string line)
            {
                IEnumerable<string> fields = null;
                using (TextReader reader = new StringReader(line))
                {
                    using (TextFieldParser parser = new TextFieldParser(reader))
                    {
                        parser.TextFieldType = FieldType.Delimited; parser.SetDelimiters(","); fields = parser.ReadFields();
                    }
                }
                return fields;
            }
        }
    }
    
