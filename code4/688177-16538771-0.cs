    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    
    public class MetricResult
    {
        public string Metric { get; set; }
        public string NewValue { get; set; }
        public string DeltaValue { get; set; }
    
    }
    
    class Program
    {
        static void Main()
        {
            // define some metric results to serialize
            var metricResults = new[] 
            { 
                new MetricResult { Metric = "metric 1", NewValue = "new value 1", DeltaValue = "delta 1" },
                new MetricResult { Metric = "metric 2", NewValue = "new value 2", DeltaValue = "delta 2" },
                new MetricResult { Metric = "metric 3", NewValue = "new value 3", DeltaValue = "delta 3" },
            }.ToList();
            var serializer = new XmlSerializer(metricResults.GetType());
    
            using (var writer = XmlWriter.Create("metrics.xml"))
            {
                // serialize the metric results we defined previously to metrics.xml
                serializer.Serialize(writer, metricResults);
            }
    
            using (var reader = XmlReader.Create("metrics.xml"))
            {
                // read metrics.xml and deserialize back
                metricResults = (List<MetricResult>)serializer.Deserialize(reader);
                foreach (var result in metricResults)
                {
                    Console.WriteLine("metric: {0}, new value: {1}, delta: {2}", result.Metric, result.NewValue, result.DeltaValue);
                }
            }
        }
    }
