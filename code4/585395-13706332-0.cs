    using System;
    using Newtonsoft.Json.Linq;
    
    namespace JSonTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = @"{""d"":[
      {
        ""__type"":""DiskSpaceInfo:#Diagnostics.Common"",
        ""AvailableSpace"":38076567552,
        ""Drive"":""C:\\"",
        ""TotalSpace"":134789197824
      },
      {
        ""__type"":""DiskSpaceInfo:#Diagnostics.Common"",
        ""AvailableSpace"":166942183424,
        ""Drive"":""D:\\"",
        ""TotalSpace"":185149157376
      }
    ]}";
            JObject o = JObject.Parse(json);
            if (o != null)
            {
                var test = o.First;
                if (test != null)
                {
                    var test2 = test.First;
                    if (test2 != null)
                    {
                        Console.Write(test2);
                    }
                }
            }
            Console.Read();
        }
    }
    }
