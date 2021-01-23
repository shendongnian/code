    using System.Windows.Forms;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    namespace _4sqCatResponse
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if(dlg.ShowDialog() != DialogResult.OK){return;}
                string json = System.IO.File.ReadAllText(dlg.FileName);
                var root = JObject.Parse(json);
                var categories = root["response"]["categories"];
                var firstCategory = categories[0];
                Console.WriteLine("id: {0}", firstCategory["id"]);
                Console.WriteLine("name: {0}", firstCategory["name"]);
                Console.WriteLine("pluralName: {0}", firstCategory["pluralName"]);
                Console.WriteLine("shortName: {0}", firstCategory["shortName"]);
                var icon = firstCategory["icon"];
                Console.WriteLine("icon.prefix: {0}", icon["prefix"]);
                Console.WriteLine("icon.sizes[0]: {0}", icon["sizes"][0]);
                Console.WriteLine("icon.name: {0}", icon["name"]);
                Console.ReadKey();
            }
        }
    }
