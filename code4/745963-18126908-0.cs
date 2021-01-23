    using System;
    using System.Collections.Generic;
    public class CsvReport
    {
        public string ShopName { get; set; }
        public string TargetVehicleName { get; set; }
    }
    class ExportToCsv<T>
    {
        List<T> data;
        public ExportToCsv(List<T> obj)
        {
            data = obj;
        }
        public void WritePropNames()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                Console.WriteLine(prop.Name);
            }
        }
    
    }
    static class Program
    {
        static void Main()
        {
            var obj = new List<CsvReport>();
            obj.Add(new CsvReport { ShopName = "Foo", TargetVehicleName = "Bar" });
            new ExportToCsv<CsvReport>(obj).WritePropNames();
        }
    }
