    using System.Security.AccessControl;
    using System.Security.Principal;
    var fs = System.IO.File.GetAccessControl(fileName);
    var sid = fs.GetOwner(typeof(SecurityIdentifier));
    Console.WriteLine(sid);
    var ntAccount = sid.Translate(typeof(NTAccount));
    Console.WriteLine(ntAccount);
