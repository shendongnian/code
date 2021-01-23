      public bool checkSignature(string path)
            {
                PowerShell shell = PowerShell.Create();
                shell.AddScript(String.Format("Get-AuthenticodeSignature {0}", path));
                Collection<PSObject> results = shell.Invoke();
                Signature check = (Signature)results[0].BaseObject;
                if (check.Status == SignatureStatus.Valid)
                {
                    return true;
                }
                return false;
            }
