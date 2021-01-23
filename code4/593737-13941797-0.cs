    using System.Security.Policy;
    ...
    Assembly myAssembly = ...;
    var zone = myAssembly.Evidence.GetHostEvidence<Zone>();
    Console.WriteLine(zone.SecurityZone);
