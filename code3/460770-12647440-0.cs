                    queue.SetPermissions(
                        "Everyone",
                        MessageQueueAccessRights.FullControl,
                        AccessControlEntryType.Allow);
                    queue.SetPermissions(
                        "ANONYMOUS LOGON",
                        MessageQueueAccessRights.FullControl,
                        AccessControlEntryType.Allow);
