    using System;
    
    namespace AppDomainEvidence
    {
        class Program
        {
            static void Main(string[] args)
            {
                var initialAppDomainEvidence = System.Threading.Thread.GetDomain().Evidence; // Setting a breakpoint here will let you inspect the current AppDomain's evidence
                try
                {
                    var usfdAttempt1 = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain(); // This will fail when the current AppDomain Evidence is instantiated via COM or in PowerShell
                }
                catch (Exception e)
                {
                    // Set breakpoint here to inspect Exception "e"
                }
    
                // Create a new Evidence that include the MyComputer zone
                var replacementEvidence = new System.Security.Policy.Evidence();
                replacementEvidence.AddHostEvidence(new System.Security.Policy.Zone(System.Security.SecurityZone.MyComputer));
    
                // Replace the current AppDomain's evidence using reflection
                var currentAppDomain = System.Threading.Thread.GetDomain();
                var securityIdentityField = currentAppDomain.GetType().GetField("_SecurityIdentity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                securityIdentityField.SetValue(currentAppDomain,replacementEvidence);
    
                var latestAppDomainEvidence = System.Threading.Thread.GetDomain().Evidence; // Setting a breakpoint here will let you inspect the current AppDomain's evidence
    
                var usfdAttempt2 = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain(); // This should work
            }
        }
    }
