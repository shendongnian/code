    using System.Windows.Forms;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.IO;
    namespace TwProfileJson
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() != DialogResult.OK) { return; }
                string json = System.IO.File.ReadAllText(dlg.FileName);
                using(MemoryStream stm = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TwitterProfile[]));
                    TwitterProfile[] pps = (TwitterProfile[])js.ReadObject(stm);
                    foreach(TwitterProfile p in pps)
                    {
                        Console.WriteLine(p.CreatedAt);
                    }
                }
                Console.ReadKey();
            }
            [DataContract]
            public class TwitterProfile
            {
                [DataMember(Name = "created_at")]
                public string CreatedAt { get; set; }
            }
        }
    }
