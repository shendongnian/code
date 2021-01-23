            UserPrincipal up = ...
            using (DirectoryEntry de = up.GetUnderlyingObject() as DirectoryEntry)
            {
                foreach (var name in de.Properties.PropertyNames)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
                // The canonicalName attribute is operational (also called constructed). 
                // Active Directory does not actually save the value, but calculates it on demand. This is probably the issue. In ADSI we use the GetInfoEx
                de.RefreshCache(new string[] { "canonicalName" });
                var canonicalName = de.Properties["canonicalName"].Value as string;
            }
