    using System.Security.Principal;
    ** code ommitted**
    string everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null).Translate(typeof(NTAccount)).Value;
    queue.SetPermissions( 
                       everyone,
                       MessageQueueAccessRights.FullControl,
                        AccessControlEntryType.Allow);
