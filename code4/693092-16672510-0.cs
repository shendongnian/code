                using (System.DirectoryServices.ActiveDirectory.Domain domain = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain())
                {
                    using (DirectoryEntry directoryEntry = domain.GetDirectoryEntry())
                    {
                        Console.WriteLine("Domain: " + domain.Name);
                        Console.WriteLine("Domain Mode: " + domain.DomainMode);
                        Console.WriteLine("Forest Mode: " + domain.Forest.ForestMode);
                        var sidInBytes = directoryEntry.Properties["objectSID"].Value as byte[];
                        var sid = new SecurityIdentifier(sidInBytes, 0);
                        Console.WriteLine("Domain SID: " + sid.ToString());
                        Console.WriteLine("Description: " + directoryEntry.Properties["description"].Value as string);
                    }
                }
