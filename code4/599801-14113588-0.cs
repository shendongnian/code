    using System;
    using System.Security.Principal;
    using System.DirectoryServices;
    using System.Linq;
    public static SecurityIdentifier GetComputerSid()
    {
        return new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid;
    }
