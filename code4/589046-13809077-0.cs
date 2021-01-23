                //Copy the file. This allows our service account to take ownership of the copied file
                var tempFileName = Path.Combine(Path.GetDirectoryName(file.FileName), "TEMP_" + file.FileNameOnly);
                File.Copy(file.FileName, tempFileName);
                
                var windowID = WindowsIdentity.GetCurrent();
                    
                var currUserName = windowID.User.Translate(typeof(NTAccount)).Value;
                var splitChar = new[] { '\\' };
                //var name = currUserName.Split(splitChar)[1];
                //var domain = currUserName.Split(splitChar)[0];
                
                var ediFileOwner = new NTAccount("TricorBraun", _radleyEDIEndpointUserAccount);
                //We have to give Access to the service account to delete the original file
                var fileSecurity = File.GetAccessControl(file.FileName);
                var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                fileSecurity.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl, AccessControlType.Allow));
                File.SetAccessControl(file.FileName, fileSecurity);
                File.Delete(file.FileName);
                
                //We rename our file to get our original file name back
                File.Move(tempFileName, file.FileName);
                //The following give our desired user permissions to take Ownership of the file.  We have to do this while running under the service account.
                fileSecurity = File.GetAccessControl(file.FileName);
                var aosSID =  (SecurityIdentifier) ediFileOwner.Translate(typeof(SecurityIdentifier));
                fileSecurity.AddAccessRule(new FileSystemAccessRule(aosSID, FileSystemRights.FullControl, AccessControlType.Allow));
                File.SetAccessControl(file.FileName, fileSecurity);
                //Now we user the Impersonator (http://www.codeproject.com/Articles/10090/A-small-C-Class-for-impersonating-a-User)
                //This allows us to manage the file as the Account we wish to change ownership to.  It makes itself the owner.
                using (new Impersonator(_radleyEDIEndpointUserAccount, "MyDomain", "password")) {
                    _logger.Debug(string.Format("Attempting changing owner to Tricorbraun\\{0}", _radleyEDIEndpointUserAccount));
                    fileSecurity = File.GetAccessControl(file.FileName);
                    fileSecurity.SetOwner(ediFileOwner); //Change our owner from LocalAdmin to our chosen DAX User
                    _logger.Debug(string.Format("Setting owner to Tricorbraun - {0}", _radleyEDIEndpointUserAccount));
                    File.SetAccessControl(file.FileName, fileSecurity);
                }
