    FileSystemAccessRule administratorRule = new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
    FileSystemAccessRule guestRule = new FileSystemAccessRule("Guest", FileSystemRights.CreateDirectories | FileSystemRights.CreateFiles, AccessControlType.Allow);
    DirectorySecurity dirSec = new DirectorySecurity();
    dirSec.AddAccessRule(administratorRule);
    dirSec.AddAccessRule(guestRule);
    Directory.CreateDirectory(@"C:\GuestTemp", dirSec);
