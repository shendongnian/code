    using System;
    using System.IO;
    using Newtonsoft.Json;
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("input.txt");
            var a = new { serverTime = "", data = new object[] { } };
            var c = new JsonSerializer();
            dynamic jsonObject = c.Deserialize(new StringReader(json), a.GetType());
            Console.WriteLine(jsonObject.data[0]);
  
