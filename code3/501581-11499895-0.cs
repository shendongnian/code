    var file = new FileInfo("copy.exe")
     var fileSecurity = file.GetAccessControl();
     fileSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                                                                    FileSystemRights.FullControl,
                                                                    AccessControlType.Allow));
     file.SetAccessControl(fileSecurity);
