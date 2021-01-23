    using System.Windows.Forms;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    namespace RptSuiteMetricsTest1
    {
        class Program
        {
            public class report_suite_metrics
            {
                public string rsid { get; set; }
                public string site_title { get; set; }
                public metric[] available_metrics { get; set; }
            }
            public class metric
            {
                public string metric_name { get; set; }
                public string display_name { get; set; }
            }
            public class AvailableMetric
            {
                public string metric_name { get; set; }
                public string display_name { get; set; }
            }
            public class RootObject
            {
                public string rsid { get; set; }
                public string site_title { get; set; }
                public List<AvailableMetric> available_metrics { get; set; }
            }
            [STAThread]
            static void Main(string[] args)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                DialogResult dr = dlg.ShowDialog();
                if (dr != DialogResult.OK) { return; }
                // NOTE: ...or replace this with a string containing the json data to test.
                string jsonData = System.IO.File.ReadAllText(dlg.FileName);
                Console.WriteLine("Deserialize as array");
                try
                {
                    report_suite_metrics[] dataset = JsonConvert.DeserializeObject<report_suite_metrics[]>(jsonData);
                    Console.WriteLine("{0} items found.", dataset.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception of type {0}", ex.GetType().Name);
                }
                Console.WriteLine("Deserialize as array, alternate type");
                try
                {
                    RootObject[] dataset = JsonConvert.DeserializeObject<RootObject[]>(jsonData);
                    Console.WriteLine("{0} items found.", dataset.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception of type {0}", ex.GetType().Name);
                }
                Console.WriteLine();
                Console.WriteLine("Deserialize as single item");
                try
                {
                    report_suite_metrics dataset = JsonConvert.DeserializeObject<report_suite_metrics>(jsonData);
                    Console.WriteLine("rsid=\"{0}\"", dataset.rsid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception of type {0}", ex.GetType().Name);
                }
                Console.WriteLine("Deserialize as single item, alternate type");
                try
                {
                    RootObject dataset = JsonConvert.DeserializeObject<RootObject>(jsonData);
                    Console.WriteLine("rsid=\"{0}\"", dataset.rsid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception of type {0}", ex.GetType().Name);
                }
                Console.ReadKey();
            }
        }
    }
