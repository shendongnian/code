    using System.IO;
    using System.Net;
    var url ="http://thebnet.x10.mx/HWID/BaseHWID/AlloweHwids.txt";
    var client = new WebClient();
    using (var stream = client.OpenRead(url))
    using (var reader = new StreamReader(stream))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            // do stuff
        }
    }
