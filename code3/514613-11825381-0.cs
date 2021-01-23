    using System.Decurity;
    using System.Security.Principal;
    ......
    SecurityIdentifier sid = new SecurityIdentifier("S-1-5-32-544");
    string name = sid.Translate(typeof(NTAccount)).Value;
    Console.WriteLine(name);
