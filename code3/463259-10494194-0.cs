    System.DirectoryServices.ActiveDirectory.Domain dom = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain();
    System.DirectoryServices.ActiveDirectory.DomainController pdcdc = dom.PdcRoleOwner;
    foreach (System.DirectoryServices.ActiveDirectory.DomainController dc in dom.DomainControllers)
                    {
                        foreach (ActiveDirectoryRole role in dc.Roles)
                        {
                            Console.WriteLine("dc : {0} role : {1}", dc.Name,role.ToString());
                        }
                    }
